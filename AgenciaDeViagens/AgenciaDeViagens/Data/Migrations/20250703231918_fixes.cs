using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaDeViagens.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoPorNoite",
                table: "Pacotes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PrecoPorNoite",
                value: 270m);

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PrecoPorNoite",
                value: 150m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PrecoPorNoite",
                table: "Pacotes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "PrecoPorNoite",
                value: 270.0);

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "PrecoPorNoite",
                value: 150.0);
        }
    }
}
