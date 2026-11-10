using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SyncModeloAzure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RutinasDetalles_Ejercicios_EjercicioID_Ejercicio",
                table: "RutinasDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_RutinasDetalles_RutinasUsuarios_RutinaUsuarioID",
                table: "RutinasDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_RutinasDetalles_EjercicioID_Ejercicio",
                table: "RutinasDetalles");

            migrationBuilder.DropIndex(
                name: "IX_RutinasDetalles_RutinaUsuarioID",
                table: "RutinasDetalles");

            migrationBuilder.DropColumn(
                name: "EjercicioID_Ejercicio",
                table: "RutinasDetalles");

            migrationBuilder.DropColumn(
                name: "RutinaUsuarioID",
                table: "RutinasDetalles");

            // Corregido a mano: SQL Server no permite quitar IDENTITY con ALTER COLUMN,
            // por eso se elimina la columna Id y se crea ID_UsuarioTipo.
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "ID_UsuarioTipo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Dia",
                table: "RutinasDetalles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Rutinas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Intensidad",
                table: "Rutinas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Rutinas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "PlanesEntrenamiento",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PlanesEntrenamiento",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nivel",
                table: "PlanesEntrenamiento",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "PlanesEntrenamiento",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Pagos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Mes",
                table: "Pagos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Pagos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "FormasPago",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Ejercicios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Dia",
                table: "DietasDetalles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "DietasDetalles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Alimento",
                table: "DietasDetalles",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Proteinas",
                table: "Alimentos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Grasas",
                table: "Alimentos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Alimentos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Carbohidratos",
                table: "Alimentos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Calorias",
                table: "Alimentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Mail");

            migrationBuilder.CreateTable(
                name: "UsuarioDietas",
                columns: table => new
                {
                    ID_Dieta = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDietas", x => new { x.ID_Dieta, x.Username });
                });

            migrationBuilder.CreateIndex(
                name: "IX_RutinasDetalles_ID_Ejercicio",
                table: "RutinasDetalles",
                column: "ID_Ejercicio");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ID_FormaPago",
                table: "Pagos",
                column: "ID_FormaPago");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ID_Plan",
                table: "Pagos",
                column: "ID_Plan");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_Username_Mes",
                table: "Pagos",
                columns: new[] { "Username", "Mes" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_FormasPago_ID_FormaPago",
                table: "Pagos",
                column: "ID_FormaPago",
                principalTable: "FormasPago",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_PlanesEntrenamiento_ID_Plan",
                table: "Pagos",
                column: "ID_Plan",
                principalTable: "PlanesEntrenamiento",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RutinasDetalles_Ejercicios_ID_Ejercicio",
                table: "RutinasDetalles",
                column: "ID_Ejercicio",
                principalTable: "Ejercicios",
                principalColumn: "ID_Ejercicio",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_FormasPago_ID_FormaPago",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_PlanesEntrenamiento_ID_Plan",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_RutinasDetalles_Ejercicios_ID_Ejercicio",
                table: "RutinasDetalles");

            migrationBuilder.DropTable(
                name: "UsuarioDietas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_RutinasDetalles_ID_Ejercicio",
                table: "RutinasDetalles");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_ID_FormaPago",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_ID_Plan",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_Username_Mes",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "ID_UsuarioTipo",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Usuarios",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Dia",
                table: "RutinasDetalles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EjercicioID_Ejercicio",
                table: "RutinasDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RutinaUsuarioID",
                table: "RutinasDetalles",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Rutinas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Intensidad",
                table: "Rutinas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Rutinas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "PlanesEntrenamiento",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "PlanesEntrenamiento",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Nivel",
                table: "PlanesEntrenamiento",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "PlanesEntrenamiento",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Pagos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Mes",
                table: "Pagos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Pagos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "FormasPago",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Ejercicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Dia",
                table: "DietasDetalles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "DietasDetalles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Alimento",
                table: "DietasDetalles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<decimal>(
                name: "Proteinas",
                table: "Alimentos",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Grasas",
                table: "Alimentos",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Alimentos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<decimal>(
                name: "Carbohidratos",
                table: "Alimentos",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Calorias",
                table: "Alimentos",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RutinasDetalles_EjercicioID_Ejercicio",
                table: "RutinasDetalles",
                column: "EjercicioID_Ejercicio");

            migrationBuilder.CreateIndex(
                name: "IX_RutinasDetalles_RutinaUsuarioID",
                table: "RutinasDetalles",
                column: "RutinaUsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_RutinasDetalles_Ejercicios_EjercicioID_Ejercicio",
                table: "RutinasDetalles",
                column: "EjercicioID_Ejercicio",
                principalTable: "Ejercicios",
                principalColumn: "ID_Ejercicio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RutinasDetalles_RutinasUsuarios_RutinaUsuarioID",
                table: "RutinasDetalles",
                column: "RutinaUsuarioID",
                principalTable: "RutinasUsuarios",
                principalColumn: "ID");
        }
    }
}
