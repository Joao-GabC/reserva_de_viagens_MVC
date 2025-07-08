using AgenciaDeViagens.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AgenciaDeViagens.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<PeriodoIndisponivel> PeriodosIndisponiveis { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PeriodoIndisponivel>()
                .HasOne(p => p.Pacote)
                .WithMany(p => p.DatasOcupadas)
                .HasForeignKey(p => p.PacoteId);

            builder.Entity<Pacote>().HasData(
                new Pacote
                {
                    Id = 1,
                    PrecoPorNoite = 270,
                    Titulo = "Pacote Completo - Ilhas Faroé",
                    Descricao = "Pacote de viagem completo para as Ilhas Faroé. Inclui estadia, voo e guia.",
                    ImagemUrl = new List<string>
                    {
                        "/img/ilhasfaroe.jpg",
                        "/img/ilhasfaroe2.jpg",
                        "/img/ilhasfaroe3.jpg",
                    },
                    NumDeVendas = 1248,
                    TextoDaPagina = "As Ilhas Faroé são um arquipélago de 18 ilhas localizadas no Atlântico Norte, entre a Islândia, a Noruega e a Escócia. Elas formam um território autônomo sob o Reino da Dinamarca e possuem cerca de 50 mil habitantes, com a capital localizada em Tórshavn.<br /><br />O clima é frio e úmido, com muita neblina, ventos fortes e chuvas frequentes. A paisagem é composta por montanhas, fiordes profundos e penhascos à beira-mar, criando um cenário dramático e isolado. A pesca é a principal atividade econômica.<br /><br />A cultura feroesa tem raízes nórdicas e é marcada pela preservação da língua feroesa, da música tradicional e de costumes antigos. Apesar do isolamento, as ilhas mantêm uma vida moderna e uma forte identidade cultural."
                },
                new Pacote
                {
                    Id = 2,
                    PrecoPorNoite = 150,
                    Titulo = "Pacote Completo - Londres",
                    Descricao = "Pacote de viagem completo para Londres. Inclui estadia, voo e guia.",
                    ImagemUrl = new List<string>
                    {
                        "/img/londres.jpg",
                        "/img/londres2.jpg",
                        "/img/londres3.jpg",
                    },
                    NumDeVendas = 3129,
                    TextoDaPagina = "Londres é a capital do Reino Unido e uma das cidades mais influentes do mundo. Localizada no sudeste da Inglaterra, às margens do rio Tâmisa, é um importante centro político, financeiro e cultural. A cidade abriga cerca de 9 milhões de pessoas e recebe milhões de turistas todos os anos.<br /><br />Entre seus marcos mais famosos estão o Big Ben, a Torre de Londres, o Palácio de Buckingham e a roda-gigante London Eye. Londres também é conhecida por seus museus, teatros e parques, como o Museu Britânico, a National Gallery e o Hyde Park.<br /><br />A cidade é extremamente diversa, com pessoas de todas as partes do mundo vivendo e trabalhando ali. Essa diversidade se reflete na culinária, nas artes e na vida cotidiana, fazendo de Londres um lugar dinâmico e multicultural."
                }
            );
            builder.Entity<PeriodoIndisponivel>().HasData(
                new PeriodoIndisponivel
                {
                    Id = 1,
                    DataInicio = new DateOnly(2026, 07, 10),
                    DataFim = new DateOnly(2026, 07, 30),
                    PacoteId = 1
                },
                new PeriodoIndisponivel
                {
                    Id = 2,
                    DataInicio = new DateOnly(2026, 08, 10),
                    DataFim = new DateOnly(2026, 08, 30),
                    PacoteId = 2
                }
            );
        }
    }
}
