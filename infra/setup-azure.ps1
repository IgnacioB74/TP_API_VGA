# =====================================================================
# Configuración inicial (UNA SOLA VEZ) de la suscripción de Azure.
# Correr desde la raíz del repo, en PowerShell, con 'az login' hecho:
#
#   powershell -ExecutionPolicy Bypass -File infra\setup-azure.ps1
#   powershell -ExecutionPolicy Bypass -File infra\setup-azure.ps1 -Location eastus2
#
# Qué hace:
#   1. Registra los proveedores de recursos que usa la API.
#   2. Crea el resource group.
#   3. Crea una identidad administrada para GitHub Actions (login OIDC,
#      sin contraseñas) con permiso Contributor sobre el resource group.
#   4. Imprime los valores a cargar como secrets en GitHub.
# =====================================================================
param(
    [string]$Location      = "centralus",
    [string]$ResourceGroup = "rg-vga-api",
    [string]$GitHubRepo    = "IgnacioB74/TP_API_VGA",
    [string]$GitHubBranch  = "master"
)

$ErrorActionPreference = "Stop"
$IdentityName = "id-github-vga"

function Invoke-Az {
    & az @args
    if ($LASTEXITCODE -ne 0) { throw "Falló: az $($args -join ' ')" }
}

Write-Host ">> Suscripción activa:" -ForegroundColor Cyan
Invoke-Az account show --query "{nombre:name, id:id, estado:state}" -o table

Write-Host ">> Registrando proveedores (puede tardar unos minutos)..." -ForegroundColor Cyan
foreach ($ns in "Microsoft.Web", "Microsoft.Sql", "Microsoft.KeyVault", "Microsoft.ManagedIdentity") {
    Write-Host "   $ns"
    Invoke-Az provider register --namespace $ns --wait
}

Write-Host ">> Creando resource group $ResourceGroup en $Location..." -ForegroundColor Cyan
Invoke-Az group create --name $ResourceGroup --location $Location -o none

Write-Host ">> Creando identidad para GitHub Actions..." -ForegroundColor Cyan
Invoke-Az identity create --name $IdentityName --resource-group $ResourceGroup -o none
$clientId    = az identity show -n $IdentityName -g $ResourceGroup --query clientId -o tsv
$principalId = az identity show -n $IdentityName -g $ResourceGroup --query principalId -o tsv
$rgId        = az group show -n $ResourceGroup --query id -o tsv

Write-Host ">> Asignando rol Contributor sobre el resource group..." -ForegroundColor Cyan
$ok = $false
for ($i = 1; $i -le 6 -and -not $ok; $i++) {
    az role assignment create --assignee-object-id $principalId --assignee-principal-type ServicePrincipal `
        --role Contributor --scope $rgId -o none
    if ($LASTEXITCODE -eq 0) { $ok = $true }
    else { Write-Host "   (la identidad todavía no se propagó, reintento en 15s)"; Start-Sleep -Seconds 15 }
}
if (-not $ok) { throw "No se pudo asignar el rol. Volvé a correr el script en un minuto." }

Write-Host ">> Creando credencial federada para $GitHubRepo ($GitHubBranch)..." -ForegroundColor Cyan
$existing = az identity federated-credential list --identity-name $IdentityName -g $ResourceGroup --query "[?name=='github-$GitHubBranch'].name" -o tsv
if (-not $existing) {
    Invoke-Az identity federated-credential create `
        --name "github-$GitHubBranch" `
        --identity-name $IdentityName `
        --resource-group $ResourceGroup `
        --issuer "https://token.actions.githubusercontent.com" `
        --subject "repo:${GitHubRepo}:ref:refs/heads/$GitHubBranch" `
        --audiences "api://AzureADTokenExchange" -o none
}

$tenantId       = az account show --query tenantId -o tsv
$subscriptionId = az account show --query id -o tsv

Write-Host ""
Write-Host "=====================================================================" -ForegroundColor Green
Write-Host " LISTO. Cargá estos secrets en GitHub:" -ForegroundColor Green
Write-Host " https://github.com/$GitHubRepo/settings/secrets/actions" -ForegroundColor Green
Write-Host "=====================================================================" -ForegroundColor Green
Write-Host " AZURE_CLIENT_ID        = $clientId"
Write-Host " AZURE_TENANT_ID        = $tenantId"
Write-Host " AZURE_SUBSCRIPTION_ID  = $subscriptionId"
Write-Host " AZURE_RESOURCE_GROUP   = $ResourceGroup"
Write-Host " SQL_ADMIN_PASSWORD     = (inventala: 12+ caracteres, mayúscula, minúscula,"
Write-Host "                           número y símbolo; sin ; ni comillas)"
Write-Host " JWT_KEY                = (inventala: 32+ caracteres)"
Write-Host "=====================================================================" -ForegroundColor Green
