# Deploy en Azure (gratis)

La infraestructura se define como código en [main.bicep](main.bicep) y la despliega
el pipeline de GitHub Actions [master_vgawebapi.yml](../.github/workflows/master_vgawebapi.yml)
en cada push a `master`.

| Recurso | Tier | Costo |
|---|---|---|
| App Service Plan + Web App (Linux, .NET 8) | F1 Free | Gratis |
| Azure SQL Database (SQL Server, serverless) | Free offer (100.000 vCore-seg/mes, 32 GB, se auto-pausa) | Gratis |
| Key Vault (secret del JWT y la cadena de conexión) | Standard | Centavos por operación |

El secret del JWT queda en el Key Vault, y la Web App lo lee con su identidad
administrada a través de la variable de ambiente `Key`
(`@Microsoft.KeyVault(SecretUri=...)`). La base se crea sola al iniciar la API
(`Database.Migrate()` en `Program.cs`, code first con EF Core).

## 1. Conseguir una suscripción gratuita

- **Azure for Students** (no pide tarjeta, da USD 100 por 12 meses):
  https://azure.microsoft.com/free/students. Se renueva cada año mientras sigas
  siendo estudiante. Si se te venció, entrá a https://portal.azure.com → *Suscripciones*,
  donde aparece la opción de renovar cuando corresponde. Si no aparece, volvé a
  registrarte desde el link de arriba con el mail de la facultad.
- **Cuenta gratuita de Azure** (pide tarjeta solo para verificar, da USD 200 por 30 días
  más los servicios gratuitos): https://azure.microsoft.com/free

Con Azure for Students solo se permiten algunas regiones. Si una falla, probá
otra (`brazilsouth`, `eastus2`, `centralus`, `westus2`...).

## 2. Configuración inicial (una sola vez)

1. Abrí **Azure Cloud Shell (Bash)**: https://shell.azure.com
2. Subí `infra/setup-azure.sh` (botón *Upload*) o pegá su contenido, y ejecutá:
   ```bash
   bash setup-azure.sh brazilsouth
   ```
3. Al final el script imprime los valores. Cargalos en GitHub en
   **Settings → Secrets and variables → Actions → New repository secret**:

   | Secret | Valor |
   |---|---|
   | `AZURE_CLIENT_ID` | el que imprime el script |
   | `AZURE_TENANT_ID` | el que imprime el script |
   | `AZURE_SUBSCRIPTION_ID` | el que imprime el script |
   | `AZURE_RESOURCE_GROUP` | `rg-vga-api` |
   | `SQL_ADMIN_PASSWORD` | uno inventado: 12+ caracteres con mayúscula, minúscula, número y símbolo, sin `;` ni comillas |
   | `JWT_KEY` | uno inventado de 32+ caracteres (ej. `openssl rand -base64 48`) |

El login de GitHub a Azure usa OIDC (identidad federada), así que no se guarda
ninguna contraseña de Azure en GitHub.

## 3. Deploy

Hacé push a `master`, o andá a **Actions → CI/CD - Infraestructura y API en Azure → Run workflow**.
El pipeline:
1. compila y publica la API,
2. crea o actualiza el App Service, el SQL y el Key Vault (Bicep),
3. despliega la API,
4. prueba que `/swagger/v1/swagger.json` responda 200.

La URL pública aparece en el log del último paso:
`https://vga-api-xxxxxxxx.azurewebsites.net` (Swagger está en la raíz).

## Notas

- **Primera request lenta:** con F1 la app se duerme por inactividad, y la base
  gratuita se auto-pausa después de 1 hora. La primera llamada puede tardar unos
  30 a 60 segundos. Antes de rendir, abrí la URL un par de minutos antes.
- **F1 da 60 minutos de CPU por día.** Para una demo sobra.
- Si el free de SQL se agota en el mes, la base se pausa hasta el mes siguiente
  y nunca te cobra.
