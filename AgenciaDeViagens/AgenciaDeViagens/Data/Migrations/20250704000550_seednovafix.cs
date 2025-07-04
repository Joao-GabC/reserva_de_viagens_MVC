using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgenciaDeViagens.Data.Migrations
{
    /// <inheritdoc />
    public partial class seednovafix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "Id", "DatasDisponiveis", "Descricao", "ImagemUrl", "PrecoPorNoite", "Titulo" },
                values: new object[,]
                {
                    { 3, "[\"2026-06-10T00:00:00\"]", "Pacote de viagem completo para as Ilhas Faroé. Inclui estadia, voo e guia.", "/img/ilhasfaroe.jpg", 270m, "Pacote Completo - Ilhas Faroé" },
                    { 4, "[\"2026-07-05T00:00:00\"]", "Pacote de viagem completo para Londres. Inclui estadia, voo e guia.", "/img/londres.jpg", 150m, "Pacote Completo - Hotel Pedra do Monte" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "Id", "DatasDisponiveis", "Descricao", "ImagemUrl", "PrecoPorNoite", "Titulo" },
                values: new object[,]
                {
                    { 1, "[\"2026-06-10T00:00:00\"]", "Pacote de viagem completo para as Ilhas Faroé. Inclui estadia, voo e guia.", "/img/ilhasfaroe.jpg", 270m, "Pacote Completo - Ilhas Faroé" },
                    { 2, "[\"2026-07-05T00:00:00\"]", "Pacote de viagem completo para Londres. Inclui estadia, voo e guia.", "/img/londres.jpg", 150m, "Pacote Completo - Hotel Pedra do Monte" }
                });
        }
    }
}
