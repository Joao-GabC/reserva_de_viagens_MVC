using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaDeViagens.Data.Migrations
{
    /// <inheritdoc />
    public partial class added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConteudoDaPagina",
                table: "Pacotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConteudoDaPagina",
                value: "Escondido entre as exuberantes matas de uma reserva nativa preservada, o Hotel Traíra Dourada é um refúgio encantador para quem deseja escapar da rotina urbana e reconectar-se com a natureza em sua forma mais pura. Combinando o charme rústico da vida florestal com o conforto e a sofisticação de um hotel de alto padrão, o Traíra Dourada oferece uma experiência única e inesquecível — seja para casais em busca de romance, famílias em férias ou aventureiros solitários.");

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConteudoDaPagina",
                value: "Aninhado entre os picos silenciosos de uma cadeia montanhosa milenar, o Hotel Pedra do Monte é um retiro acolhedor e sofisticado para quem busca contemplação, aventura e bem-estar. Com uma vista panorâmica de tirar o fôlego, ar puro das alturas e o aconchego das lareiras crepitando ao entardecer, o Pedra do Monte convida você a desacelerar, respirar e se maravilhar com a imensidão da natureza.\r\n\r\nCom arquitetura inspirada nos refúgios alpinos europeus e toques rústicos da cultura local, o hotel se harmoniza com o relevo acidentado e as formações rochosas que cercam a propriedade — especialmente a imponente Pedra do Monte, que dá nome ao lugar e vigia silenciosa cada nascer do sol.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConteudoDaPagina",
                table: "Pacotes");
        }
    }
}
