using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    PreguntaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enunciado = table.Column<string>(maxLength: 190, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.PreguntaId);
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
                        name: "FK_Respuestas_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "PreguntaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    IdRestaurante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 35, nullable: true),
                    Direccion = table.Column<string>(maxLength: 40, nullable: true),
                    Identificacion = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.IdRestaurante);
                });

            migrationBuilder.CreateTable(
                name: "ListasDeChequeo",
                columns: table => new
                {
                    ListaChequeoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestauranteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasDeChequeo", x => x.ListaChequeoId);
                    table.ForeignKey(
                        name: "FK_ListasDeChequeo_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "IdRestaurante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(maxLength: 11, nullable: false),
                    Nombres = table.Column<string>(maxLength: 30, nullable: true),
                    PrimerApellido = table.Column<string>(maxLength: 15, nullable: true),
                    SegundoApellido = table.Column<string>(maxLength: 15, nullable: true),
                    Sexo = table.Column<string>(maxLength: 9, nullable: true),
                    Edad = table.Column<int>(type: "Int", nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EstadoCivil = table.Column<string>(maxLength: 15, nullable: true),
                    PaisDeProcedencia = table.Column<string>(maxLength: 15, nullable: true),
                    NivelEducativo = table.Column<string>(maxLength: 15, nullable: true),
                    RestauranteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Personas_Restaurantes_RestauranteId",
                        column: x => x.RestauranteId,
                        principalTable: "Restaurantes",
                        principalColumn: "IdRestaurante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoUsuario = table.Column<string>(maxLength: 25, nullable: true),
                    NombreUsuario = table.Column<string>(maxLength: 20, nullable: true),
                    Contraseña = table.Column<string>(maxLength: 20, nullable: true),
                    Identificacion = table.Column<string>(maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_Identificacion",
                        column: x => x.Identificacion,
                        principalTable: "Personas",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListasDeChequeo_RestauranteId",
                table: "ListasDeChequeo",
                column: "RestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_RestauranteId",
                table: "Personas",
                column: "RestauranteId");

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
                name: "IX_Restaurantes_Identificacion",
                table: "Restaurantes",
                column: "Identificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Identificacion",
                table: "Usuarios",
                column: "Identificacion");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestaChequeo_ListasDeChequeo_ListaChequeoId",
                table: "RespuestaChequeo",
                column: "ListaChequeoId",
                principalTable: "ListasDeChequeo",
                principalColumn: "ListaChequeoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Respuestas_Personas_Identificacion",
                table: "Respuestas",
                column: "Identificacion",
                principalTable: "Personas",
                principalColumn: "Identificacion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurantes_Personas_Identificacion",
                table: "Restaurantes",
                column: "Identificacion",
                principalTable: "Personas",
                principalColumn: "Identificacion",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Restaurantes_RestauranteId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "RespuestaChequeo");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "ListasDeChequeo");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
