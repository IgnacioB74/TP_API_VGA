// =====================================================================
// Infraestructura de la API (Virtual Gym Assistant) en Azure
// Todo en tiers gratuitos:
//   - App Service Plan F1 (Linux)            -> gratis
//   - Azure SQL Database (free offer)        -> gratis (100.000 vCore-seg/mes, 32 GB)
//   - Key Vault (secret del JWT y conexión)  -> centavos por operación
// La despliega el workflow .github/workflows/master_vgawebapi.yml
// =====================================================================

@description('Región de los recursos. Con Azure for Students solo se permiten algunas regiones.')
param location string = resourceGroup().location

@description('Región del SQL Server (a veces una región no admite SQL en cuentas de estudiante).')
param sqlLocation string = location

@description('Nombre de la Web App (debe ser único en todo Azure).')
param webAppName string = 'vga-api-${uniqueString(resourceGroup().id)}'

@description('Usuario administrador del SQL Server.')
param sqlAdminLogin string = 'vgaadmin'

@secure()
@description('Contraseña del administrador del SQL Server (sin ; ni comillas).')
param sqlAdminPassword string

@secure()
@description('Secret para firmar los tokens JWT (mínimo 32 caracteres).')
param jwtKey string

var suffix = uniqueString(resourceGroup().id)
var planName = 'plan-vga-${suffix}'
var sqlServerName = 'sql-vga-${suffix}'
var databaseName = 'VirtualGymAssistant'
var keyVaultName = 'kv-vga-${suffix}'

// ---------------------------------------------------------------------
// App Service (F1 gratuito, Linux, .NET 8)
// ---------------------------------------------------------------------
resource plan 'Microsoft.Web/serverfarms@2023-12-01' = {
  name: planName
  location: location
  kind: 'linux'
  sku: {
    name: 'F1'
    tier: 'Free'
  }
  properties: {
    reserved: true // requerido para Linux
  }
}

resource webApp 'Microsoft.Web/sites@2023-12-01' = {
  name: webAppName
  location: location
  kind: 'app,linux'
  identity: {
    type: 'SystemAssigned' // identidad administrada para leer el Key Vault
  }
  properties: {
    serverFarmId: plan.id
    httpsOnly: true
    siteConfig: {
      linuxFxVersion: 'DOTNETCORE|8.0'
      appCommandLine: 'dotnet Presentation.dll'
      alwaysOn: false // F1 no soporta Always On
      ftpsState: 'Disabled'
      minTlsVersion: '1.2'
    }
  }
}

// ---------------------------------------------------------------------
// Azure SQL (oferta gratuita, serverless con auto-pausa)
// ---------------------------------------------------------------------
resource sqlServer 'Microsoft.Sql/servers@2023-08-01-preview' = {
  name: sqlServerName
  location: sqlLocation
  properties: {
    administratorLogin: sqlAdminLogin
    administratorLoginPassword: sqlAdminPassword
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
  }
}

// Permite que los servicios de Azure (la Web App) se conecten al SQL
resource sqlFirewallAzure 'Microsoft.Sql/servers/firewallRules@2023-08-01-preview' = {
  parent: sqlServer
  name: 'AllowAllWindowsAzureIps'
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '0.0.0.0'
  }
}

resource database 'Microsoft.Sql/servers/databases@2023-08-01-preview' = {
  parent: sqlServer
  name: databaseName
  location: sqlLocation
  sku: {
    name: 'GP_S_Gen5'
    tier: 'GeneralPurpose'
    family: 'Gen5'
    capacity: 2
  }
  properties: {
    useFreeLimit: true                       // oferta gratuita de Azure SQL
    freeLimitExhaustionBehavior: 'AutoPause' // si se agota el free, se pausa (nunca cobra)
    autoPauseDelay: 60
    minCapacity: json('0.5')
    maxSizeBytes: 34359738368                // 32 GB
    requestedBackupStorageRedundancy: 'Local'
  }
}

// ---------------------------------------------------------------------
// Key Vault con los secrets (JWT y cadena de conexión)
// ---------------------------------------------------------------------
resource keyVault 'Microsoft.KeyVault/vaults@2023-07-01' = {
  name: keyVaultName
  location: location
  properties: {
    tenantId: subscription().tenantId
    sku: {
      family: 'A'
      name: 'standard'
    }
    enableRbacAuthorization: false
    accessPolicies: [
      {
        // La Web App puede leer los secrets con su identidad administrada
        tenantId: subscription().tenantId
        objectId: webApp.identity.principalId
        permissions: {
          secrets: [ 'get', 'list' ]
        }
      }
    ]
  }
}

resource jwtSecret 'Microsoft.KeyVault/vaults/secrets@2023-07-01' = {
  parent: keyVault
  name: 'JwtKey'
  properties: {
    value: jwtKey
  }
}

resource sqlConnectionSecret 'Microsoft.KeyVault/vaults/secrets@2023-07-01' = {
  parent: keyVault
  name: 'SqlConnectionString'
  properties: {
    value: 'Server=tcp:${sqlServer.properties.fullyQualifiedDomainName},1433;Initial Catalog=${databaseName};User ID=${sqlAdminLogin};Password=${sqlAdminPassword};Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;'
  }
}

// ---------------------------------------------------------------------
// Variables de ambiente de la Web App -> referencias al Key Vault
// ("Key" es la que lee Program.cs / AuthService para el JWT)
// ---------------------------------------------------------------------
resource appSettings 'Microsoft.Web/sites/config@2023-12-01' = {
  parent: webApp
  name: 'appsettings'
  properties: {
    ASPNETCORE_ENVIRONMENT: 'Production'
    Key: '@Microsoft.KeyVault(SecretUri=${jwtSecret.properties.secretUri})'
    ConnectionStrings__DefaultConnection: '@Microsoft.KeyVault(SecretUri=${sqlConnectionSecret.properties.secretUri})'
  }
}

output webAppName string = webApp.name
output webAppUrl string = 'https://${webApp.properties.defaultHostName}'
output keyVaultName string = keyVault.name
output sqlServerFqdn string = sqlServer.properties.fullyQualifiedDomainName
