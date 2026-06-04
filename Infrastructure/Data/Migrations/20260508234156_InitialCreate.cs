using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlimentosCategorias",
                columns: table => new
                {
                    ID_Categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentosCategorias", x => x.ID_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "AlimentosObjetivos",
                columns: table => new
                {
                    ID_Objetivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentosObjetivos", x => x.ID_Objetivo);
                });

            migrationBuilder.CreateTable(
                name: "CarouselItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    ID_Cuota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.ID_Cuota);
                });

            migrationBuilder.CreateTable(
                name: "DietasDetalles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Dieta = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alimento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietasDetalles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FooterConfigs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterConfigs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FormasPago",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPago", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GruposMusculares",
                columns: table => new
                {
                    ID_Grupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposMusculares", x => x.ID_Grupo);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_FormaPago = table.Column<int>(type: "int", nullable: false),
                    ID_Plan = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanesEntrenamiento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesEntrenamiento", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rutinas",
                columns: table => new
                {
                    ID_Rutina = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intensidad = table.Column<int>(type: "int", nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    EjerciciosXDia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutinas", x => x.ID_Rutina);
                });

            migrationBuilder.CreateTable(
                name: "RutinasUsuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutinasUsuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    ID_Alimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Calorias = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Proteinas = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Carbohidratos = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Grasas = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Categoria = table.Column<int>(type: "int", nullable: false),
                    ID_Objetivo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.ID_Alimento);
                    table.ForeignKey(
                        name: "FK_Alimentos_AlimentosCategorias_ID_Categoria",
                        column: x => x.ID_Categoria,
                        principalTable: "AlimentosCategorias",
                        principalColumn: "ID_Categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alimentos_AlimentosObjetivos_ID_Objetivo",
                        column: x => x.ID_Objetivo,
                        principalTable: "AlimentosObjetivos",
                        principalColumn: "ID_Objetivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicios",
                columns: table => new
                {
                    ID_Ejercicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Grupo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicios", x => x.ID_Ejercicio);
                    table.ForeignKey(
                        name: "FK_Ejercicios_GruposMusculares_ID_Grupo",
                        column: x => x.ID_Grupo,
                        principalTable: "GruposMusculares",
                        principalColumn: "ID_Grupo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RutinasDetalles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_RutinaUsuario = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    ID_Ejercicio = table.Column<int>(type: "int", nullable: false),
                    EjercicioID_Ejercicio = table.Column<int>(type: "int", nullable: false),
                    RutinaUsuarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutinasDetalles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RutinasDetalles_Ejercicios_EjercicioID_Ejercicio",
                        column: x => x.EjercicioID_Ejercicio,
                        principalTable: "Ejercicios",
                        principalColumn: "ID_Ejercicio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RutinasDetalles_RutinasUsuarios_RutinaUsuarioID",
                        column: x => x.RutinaUsuarioID,
                        principalTable: "RutinasUsuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_ID_Categoria",
                table: "Alimentos",
                column: "ID_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_ID_Objetivo",
                table: "Alimentos",
                column: "ID_Objetivo");

            migrationBuilder.CreateIndex(
                name: "IX_Ejercicios_ID_Grupo",
                table: "Ejercicios",
                column: "ID_Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_RutinasDetalles_EjercicioID_Ejercicio",
                table: "RutinasDetalles",
                column: "EjercicioID_Ejercicio");

            migrationBuilder.CreateIndex(
                name: "IX_RutinasDetalles_RutinaUsuarioID",
                table: "RutinasDetalles",
                column: "RutinaUsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "CarouselItems");

            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "DietasDetalles");

            migrationBuilder.DropTable(
                name: "FooterConfigs");

            migrationBuilder.DropTable(
                name: "FormasPago");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PlanesEntrenamiento");

            migrationBuilder.DropTable(
                name: "Rutinas");

            migrationBuilder.DropTable(
                name: "RutinasDetalles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "AlimentosCategorias");

            migrationBuilder.DropTable(
                name: "AlimentosObjetivos");

            migrationBuilder.DropTable(
                name: "Ejercicios");

            migrationBuilder.DropTable(
                name: "RutinasUsuarios");

            migrationBuilder.DropTable(
                name: "GruposMusculares");
        }
    }
}
