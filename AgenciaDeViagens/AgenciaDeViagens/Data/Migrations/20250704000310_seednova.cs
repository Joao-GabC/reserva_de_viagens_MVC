using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaDeViagens.Data.Migrations
{
    /// <inheritdoc />
    public partial class seednova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConteudoDaPagina",
                table: "Pacotes",
                newName: "DatasDisponiveis");

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DatasDisponiveis", "Descricao", "ImagemUrl", "Titulo" },
                values: new object[] { "[\"2026-06-10T00:00:00\"]", "Pacote de viagem completo para as Ilhas Faroé. Inclui estadia, voo e guia.", "/img/ilhasfaroe.jpg", "Pacote Completo - Ilhas Faroé" });

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DatasDisponiveis", "Descricao", "ImagemUrl" },
                values: new object[] { "[\"2026-07-05T00:00:00\"]", "Pacote de viagem completo para Londres. Inclui estadia, voo e guia.", "/img/londres.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DatasDisponiveis",
                table: "Pacotes",
                newName: "ConteudoDaPagina");

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConteudoDaPagina", "Descricao", "ImagemUrl", "Titulo" },
                values: new object[] { "Escondido entre as exuberantes matas de uma reserva nativa preservada, o Hotel Traíra Dourada é um refúgio encantador para quem deseja escapar da rotina urbana e reconectar-se com a natureza em sua forma mais pura. Combinando o charme rústico da vida florestal com o conforto e a sofisticação de um hotel de alto padrão, o Traíra Dourada oferece uma experiência única e inesquecível — seja para casais em busca de romance, famílias em férias ou aventureiros solitários.", "Pacote para o Hotel Traíra Dourada que inclui café da manhã, almoço e jantar.", "/img/trairadourada.jpg", "Pacote Completo - Hotel Traíra Dourada" });

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConteudoDaPagina", "Descricao", "ImagemUrl" },
                values: new object[] { "Aninhado entre os picos silenciosos de uma cadeia montanhosa milenar, o Hotel Pedra do Monte é um retiro acolhedor e sofisticado para quem busca contemplação, aventura e bem-estar. Com uma vista panorâmica de tirar o fôlego, ar puro das alturas e o aconchego das lareiras crepitando ao entardecer, o Pedra do Monte convida você a desacelerar, respirar e se maravilhar com a imensidão da natureza.\r\n\r\nCom arquitetura inspirada nos refúgios alpinos europeus e toques rústicos da cultura local, o hotel se harmoniza com o relevo acidentado e as formações rochosas que cercam a propriedade — especialmente a imponente Pedra do Monte, que dá nome ao lugar e vigia silenciosa cada nascer do sol.", "Pacote para o Hotel Pedra do Monte que inclui café da manhã, almoço e jantar.", "/img/pedradomonte.jpg" });
        }
    }
}
