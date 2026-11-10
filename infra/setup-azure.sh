#!/usr/bin/env bash
# =====================================================================
# Configuración inicial (UNA SOLA VEZ) de la suscripción de Azure.
# Correrlo en Azure Cloud Shell (Bash): https://shell.azure.com
#
#   bash setup-azure.sh                 # usa los valores por defecto
#   bash setup-azure.sh brazilsouth     # elegir región
#
# Qué hace:
#   1. Registra los proveedores de recursos que usa la API.
#   2. Crea el resource group.
#   3. Crea una identidad administrada para GitHub Actions (login OIDC,
#      sin contraseñas guardadas) con permiso Contributor sobre el RG.
#   4. Imprime los valores a cargar como secrets en GitHub.
# =====================================================================
set -euo pipefail

LOCATION="${1:-brazilsouth}"
RESOURCE_GROUP="${RESOURCE_GROUP:-rg-vga-api}"
GITHUB_REPO="${GITHUB_REPO:-IgnacioB74/TP_API_VGA}"
GITHUB_BRANCH="${GITHUB_BRANCH:-master}"
IDENTITY_NAME="id-github-vga"

echo ">> Suscripción activa:"
az account show --query "{nombre:name, id:id}" -o table

echo ">> Registrando proveedores (puede tardar unos minutos)..."
for ns in Microsoft.Web Microsoft.Sql Microsoft.KeyVault Microsoft.ManagedIdentity; do
  az provider register --namespace "$ns" --wait
done

echo ">> Creando resource group $RESOURCE_GROUP en $LOCATION..."
az group create --name "$RESOURCE_GROUP" --location "$LOCATION" -o none

echo ">> Creando identidad para GitHub Actions..."
az identity create --name "$IDENTITY_NAME" --resource-group "$RESOURCE_GROUP" -o none
CLIENT_ID=$(az identity show -n "$IDENTITY_NAME" -g "$RESOURCE_GROUP" --query clientId -o tsv)
PRINCIPAL_ID=$(az identity show -n "$IDENTITY_NAME" -g "$RESOURCE_GROUP" --query principalId -o tsv)
RG_ID=$(az group show -n "$RESOURCE_GROUP" --query id -o tsv)

echo ">> Asignando rol Contributor sobre el resource group..."
for i in 1 2 3 4 5; do
  az role assignment create \
    --assignee-object-id "$PRINCIPAL_ID" \
    --assignee-principal-type ServicePrincipal \
    --role Contributor \
    --scope "$RG_ID" -o none && break
  echo "   (la identidad todavía no se propagó, reintentando en 15s)"; sleep 15
done

echo ">> Creando credencial federada para $GITHUB_REPO ($GITHUB_BRANCH)..."
az identity federated-credential create \
  --name "github-$GITHUB_BRANCH" \
  --identity-name "$IDENTITY_NAME" \
  --resource-group "$RESOURCE_GROUP" \
  --issuer "https://token.actions.githubusercontent.com" \
  --subject "repo:$GITHUB_REPO:ref:refs/heads/$GITHUB_BRANCH" \
  --audiences "api://AzureADTokenExchange" -o none

cat <<EOF

=====================================================================
 LISTO. Cargá estos valores en GitHub:
 Repo -> Settings -> Secrets and variables -> Actions -> New repository secret
=====================================================================
 AZURE_CLIENT_ID        = $CLIENT_ID
 AZURE_TENANT_ID        = $(az account show --query tenantId -o tsv)
 AZURE_SUBSCRIPTION_ID  = $(az account show --query id -o tsv)
 AZURE_RESOURCE_GROUP   = $RESOURCE_GROUP
 SQL_ADMIN_PASSWORD     = (inventá una: 12+ caracteres, mayúscula, minúscula,
                           número y símbolo; sin ; ni comillas)
 JWT_KEY                = (inventá una de 32+ caracteres, ej: la salida de
                           'openssl rand -base64 48')
=====================================================================
EOF
