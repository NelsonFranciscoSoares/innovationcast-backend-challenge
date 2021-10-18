using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Challenge.Infrastructure.Persistence.Migrations
{
    public partial class mappedenumfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entidades",
                keyColumn: "Id",
                keyValue: new Guid("2a2167a9-2714-4cb7-8556-212cd9ebba7b"));

            migrationBuilder.DeleteData(
                table: "Entidades",
                keyColumn: "Id",
                keyValue: new Guid("8d2f019a-03e3-44da-a372-ffa1f8370623"));

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: new Guid("11a4a979-05b1-45ff-b875-5852abf5da75"));

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: new Guid("184a9890-e15d-43eb-989e-87db80eac0bd"));

            migrationBuilder.AddColumn<string>(
                name: "TipoComentario",
                table: "Entidades",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "DataEdicao", "DataInsercao", "Email", "Username" },
                values: new object[,]
                {
                    { new Guid("fea51e65-a4eb-413b-853c-586a7e5cbb51"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "teste01@gmail.com", "Teste01" },
                    { new Guid("bb8704ab-e56e-4ca2-bbec-b5421aec8a4a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "teste02@gmail.com", "Teste02" }
                });

            migrationBuilder.InsertData(
                table: "Entidades",
                columns: new[] { "Id", "DataEdicao", "DataInsercao", "TipoComentario", "UtilizadorId" },
                values: new object[,]
                {
                    { new Guid("259ba75a-9b6b-4105-a92a-d65f9d117e26"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "IDEIA", new Guid("fea51e65-a4eb-413b-853c-586a7e5cbb51") },
                    { new Guid("f1ba106a-d716-43c1-964e-eb96a91e966b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "IDEIA", new Guid("bb8704ab-e56e-4ca2-bbec-b5421aec8a4a") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entidades",
                keyColumn: "Id",
                keyValue: new Guid("259ba75a-9b6b-4105-a92a-d65f9d117e26"));

            migrationBuilder.DeleteData(
                table: "Entidades",
                keyColumn: "Id",
                keyValue: new Guid("f1ba106a-d716-43c1-964e-eb96a91e966b"));

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: new Guid("bb8704ab-e56e-4ca2-bbec-b5421aec8a4a"));

            migrationBuilder.DeleteData(
                table: "Utilizadores",
                keyColumn: "Id",
                keyValue: new Guid("fea51e65-a4eb-413b-853c-586a7e5cbb51"));

            migrationBuilder.DropColumn(
                name: "TipoComentario",
                table: "Entidades");

            migrationBuilder.InsertData(
                table: "Utilizadores",
                columns: new[] { "Id", "DataEdicao", "DataInsercao", "Email", "Username" },
                values: new object[,]
                {
                    { new Guid("184a9890-e15d-43eb-989e-87db80eac0bd"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "teste01@gmail.com", "Teste01" },
                    { new Guid("11a4a979-05b1-45ff-b875-5852abf5da75"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "teste02@gmail.com", "Teste02" }
                });

            migrationBuilder.InsertData(
                table: "Entidades",
                columns: new[] { "Id", "DataEdicao", "DataInsercao", "UtilizadorId" },
                values: new object[,]
                {
                    { new Guid("2a2167a9-2714-4cb7-8556-212cd9ebba7b"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("184a9890-e15d-43eb-989e-87db80eac0bd") },
                    { new Guid("8d2f019a-03e3-44da-a372-ffa1f8370623"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("11a4a979-05b1-45ff-b875-5852abf5da75") }
                });
        }
    }
}
