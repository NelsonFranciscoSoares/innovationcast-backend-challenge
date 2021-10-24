using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Challenge.Infrastructure.Persistence.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataInsercao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoComentario = table.Column<string>(type: "text", nullable: false),
                    UtilizadorEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataInsercao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entidades_Utilizadores_UtilizadorEntityId",
                        column: x => x.UtilizadorEntityId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    DataInsercao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DataEdicao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
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
                    Visualizado_PorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioEntityUtilizadorEntity", x => new { x.ComentariosVisualizadosId, x.Visualizado_PorId });
                    table.ForeignKey(
                        name: "FK_ComentarioEntityUtilizadorEntity_Comentarios_ComentariosVis~",
                        column: x => x.ComentariosVisualizadosId,
                        principalTable: "Comentarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioEntityUtilizadorEntity_Utilizadores_Visualizado_P~",
                        column: x => x.Visualizado_PorId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Entidades",
                columns: new[] { "Id", "DataEdicao", "DataInsercao", "TipoComentario", "UtilizadorEntityId" },
                values: new object[,]
                {
                    { new Guid("d5e9db95-4cac-44d7-9faa-d132140dfb2a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "IDEIA", null },
                    { new Guid("57819973-7eb4-4d19-87a0-c30b684a6546"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "SINAIS", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioEntityUtilizadorEntity_Visualizado_PorId",
                table: "ComentarioEntityUtilizadorEntity",
                column: "Visualizado_PorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_EntidadeId",
                table: "Comentarios",
                column: "EntidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_UtilizadorEntityId",
                table: "Entidades",
                column: "UtilizadorEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioEntityUtilizadorEntity");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Entidades");

            migrationBuilder.DropTable(
                name: "Utilizadores");
        }
    }
}
