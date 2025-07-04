using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgenciaDeViagens.Data.Migrations
{
    /// <inheritdoc />
    public partial class seednovafix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "DatasDisponiveis",
                table: "Pacotes");

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "Id", "Descricao", "ImagemUrl", "PrecoPorNoite", "Titulo" },
                values: new object[,]
                {
                    { 5, "Pacote de viagem completo para as Ilhas Faroé. Inclui estadia, voo e guia.", "/img/ilhasfaroe.jpg", 270m, "Pacote Completo - Ilhas Faroé" },
                    { 6, "Pacote de viagem completo para Londres. Inclui estadia, voo e guia.", "/img/londres.jpg", 150m, "Pacote Completo - Hotel Pedra do Monte" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "DatasDisponiveis",
                table: "Pacotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "Id", "DatasDisponiveis", "Descricao", "ImagemUrl", "PrecoPorNoite", "Titulo" },
                values: new object[,]
                {
                    { 3, "[\"2026-06-10T00:00:00\"]", "Pacote de viagem completo para as Ilhas Faroé. Inclui estadia, voo e guia.", "/img/ilhasfaroe.jpg", 270m, "Pacote Completo - Ilhas Faroé" },
                    { 4, "[\"2026-07-05T00:00:00\"]", "Pacote de viagem completo para Londres. Inclui estadia, voo e guia.", "/img/londres.jpg", 150m, "Pacote Completo - Hotel Pedra do Monte" }
                });
        }
    }
}
