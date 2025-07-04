using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgenciaDeViagens.Data.Migrations
{
    /// <inheritdoc />
    public partial class seednovafix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.CreateTable(
                name: "PeriodosIndisponiveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosIndisponiveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodosIndisponiveis_Pacotes_PacoteId",
                        column: x => x.PacoteId,
                        principalTable: "Pacotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "Id", "Descricao", "ImagemUrl", "PrecoPorNoite", "Titulo" },
                values: new object[,]
                {
                    { 7, "Pacote de viagem completo para as Ilhas Faroé. Inclui estadia, voo e guia.", "/img/ilhasfaroe.jpg", 270m, "Pacote Completo - Ilhas Faroé" },
                    { 8, "Pacote de viagem completo para Londres. Inclui estadia, voo e guia.", "/img/londres.jpg", 150m, "Pacote Completo - Hotel Pedra do Monte" }
                });

            migrationBuilder.InsertData(
                table: "PeriodosIndisponiveis",
                columns: new[] { "Id", "DataFim", "DataInicio", "PacoteId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 2, new DateTime(2026, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosIndisponiveis_PacoteId",
                table: "PeriodosIndisponiveis",
                column: "PacoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodosIndisponiveis");

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "Id", "Descricao", "ImagemUrl", "PrecoPorNoite", "Titulo" },
                values: new object[,]
                {
                    { 5, "Pacote de viagem completo para as Ilhas Faroé. Inclui estadia, voo e guia.", "/img/ilhasfaroe.jpg", 270m, "Pacote Completo - Ilhas Faroé" },
                    { 6, "Pacote de viagem completo para Londres. Inclui estadia, voo e guia.", "/img/londres.jpg", 150m, "Pacote Completo - Hotel Pedra do Monte" }
                });
        }
    }
}
