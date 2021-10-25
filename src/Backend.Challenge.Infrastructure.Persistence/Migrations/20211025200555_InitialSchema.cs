using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Challenge.Infrastructure.Persistence.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoComentario = table.Column<string>(type: "text", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntidadeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Texto = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    Autor = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DataPublicacao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DataInsercao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Entidades_EntidadeId",
                        column: x => x.EntidadeId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioEntityUtilizadorEntity",
                columns: table => new
                {
                    ComentariosVisualizadosId = table.Column<Guid>(type: "uuid", nullable: false),
                    UtilizadoresVisualizaramId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEntityUtilizadorEntity", x => new { x.ComentariosVisualizadosId, x.UtilizadoresVisualizaramId });
                    table.ForeignKey(
                        name: "FK_ComentarioEntityUtilizadorEntity_Comentarios_ComentariosVis~",
                        column: x => x.ComentariosVisualizadosId,
                        principalTable: "Comentarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioEntityUtilizadorEntity_Utilizadores_UtilizadoresV~",
                        column: x => x.UtilizadoresVisualizaramId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Entidades",
                columns: new[] { "Id", "DataEdicao", "DataInsercao", "TipoComentario" },
                values: new object[,]
                {
                    { new Guid("06406200-c8ee-44e1-bf86-bc5827048705"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IDEIA" },
                    { new Guid("21738160-0178-42c6-8b9e-c60f8fab459d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SINAIS" }
                });

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "DataEdicao", "DataInsercao", "Email", "Username" },
                values: new object[,]
                {
                    { new Guid("abea8a1e-d8e2-47f7-b7e7-6dd6cfe48ac4"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fake.nfsoares@gmail.com", "nfsoares" },
                    { new Guid("2d4305a4-0481-4ced-85dc-2d2a09a99431"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fake.teste01@gmail.com", "teste01" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEntityUtilizadorEntity_UtilizadoresVisualizaramId",
                table: "ComentarioEntityUtilizadorEntity",
                column: "UtilizadoresVisualizaramId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_EntidadeId",
                table: "Comentarios",
                column: "EntidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEntityUtilizadorEntity");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Entidades");
        }
    }
}
