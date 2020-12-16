using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class inicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    PreguntaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enunciado = table.Column<string>(maxLength: 190, nullable: true),
                    PerteneceA = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.PreguntaId);
                });

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 11, nullable: false),
                    Nombres = table.Column<string>(maxLength: 30, nullable: true),
                    PrimerApellido = table.Column<string>(maxLength: 15, nullable: true),
                    SegundoApellido = table.Column<string>(maxLength: 15, nullable: true),
                    Sexo = table.Column<string>(maxLength: 9, nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    NombreUsuario = table.Column<string>(maxLength: 20, nullable: false),
                    Identificacion = table.Column<string>(maxLength: 11, nullable: true),
                    Nombres = table.Column<string>(maxLength: 30, nullable: true),
                    PrimerApellido = table.Column<string>(maxLength: 15, nullable: true),
                    SegundoApellido = table.Column<string>(maxLength: 15, nullable: true),
                    Sexo = table.Column<string>(maxLength: 9, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Contrasena = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 25, nullable: true),
                    Rol = table.Column<string>(maxLength: 25, nullable: true),
                    Estado = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.NombreUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    NIT = table.Column<string>(maxLength: 15, nullable: false),
                    Nombre = table.Column<string>(maxLength: 35, nullable: true),
                    PropietarioIdentificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.NIT);
                    table.ForeignKey(
                        name: "FK_Restaurantes_Propietario_PropietarioIdentificacion",
                        column: x => x.PropietarioIdentificacion,
                        principalTable: "Propietario",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    SedeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Direccion = table.Column<string>(maxLength: 40, nullable: true),
                    Telefono = table.Column<string>(maxLength: 10, nullable: true),
                    RestauranteId = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.SedeId);
                    table.ForeignKey(
                        name: "FK_Sedes_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "NIT",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListasDeChequeo",
                columns: table => new
                {
                    ListaChequeoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    SedeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasDeChequeo", x => x.ListaChequeoId);
                    table.ForeignKey(
                        name: "FK_ListasDeChequeo_Sedes_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sedes",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manipuladores",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 11, nullable: false),
                    Nombres = table.Column<string>(maxLength: 30, nullable: true),
                    PrimerApellido = table.Column<string>(maxLength: 15, nullable: true),
                    SegundoApellido = table.Column<string>(maxLength: 15, nullable: true),
                    Sexo = table.Column<string>(maxLength: 9, nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    EstadoCivil = table.Column<string>(maxLength: 15, nullable: true),
                    PaisDeProcedencia = table.Column<string>(maxLength: 15, nullable: true),
                    NivelEducativo = table.Column<string>(maxLength: 15, nullable: true),
                    SedeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manipuladores", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Manipuladores_Sedes_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sedes",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespuestaChequeo",
                columns: table => new
                {
                    RespuestaChequeoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContenidoRespuesta = table.Column<string>(maxLength: 200, nullable: true),
                    Puntaje = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PreguntaId = table.Column<int>(nullable: false),
                    ListaChequeoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaChequeo", x => x.RespuestaChequeoId);
                    table.ForeignKey(
                        name: "FK_RespuestaChequeo_ListasDeChequeo_ListaChequeoId",
                        column: x => x.ListaChequeoId,
                        principalTable: "ListasDeChequeo",
                        principalColumn: "ListaChequeoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RespuestaChequeo_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    RespuestaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContenidoRespuesta = table.Column<string>(maxLength: 100, nullable: true),
                    PreguntaId = table.Column<int>(nullable: false),
                    Identificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.RespuestaId);
                    table.ForeignKey(
                        name: "FK_Respuestas_Manipuladores_Identificacion",
                        column: x => x.Identificacion,
                        principalTable: "Manipuladores",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListasDeChequeo_SedeId",
                table: "ListasDeChequeo",
                column: "SedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Manipuladores_SedeId",
                table: "Manipuladores",
                column: "SedeId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaChequeo_ListaChequeoId",
                table: "RespuestaChequeo",
                column: "ListaChequeoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaChequeo_PreguntaId",
                table: "RespuestaChequeo",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_Identificacion",
                table: "Respuestas",
                column: "Identificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurantes_PropietarioIdentificacion",
                table: "Restaurantes",
                column: "PropietarioIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_RestauranteId",
                table: "Sedes",
                column: "RestauranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespuestaChequeo");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ListasDeChequeo");

            migrationBuilder.DropTable(
                name: "Manipuladores");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "Propietario");
        }
    }
}
