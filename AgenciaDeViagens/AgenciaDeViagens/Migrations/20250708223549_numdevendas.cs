using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaDeViagens.Migrations
{
    /// <inheritdoc />
    public partial class numdevendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumDeVendas",
                table: "Pacotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "NumDeVendas",
                value: 1248);

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "NumDeVendas",
                value: 3129);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumDeVendas",
                table: "Pacotes");
        }
    }
}
