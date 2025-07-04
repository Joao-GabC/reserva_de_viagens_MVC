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
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<PeriodoIndisponivel> PeriodosIndisponiveis{ get; set; }

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
                    Id = 7,
                    PrecoPorNoite = 270,
                    Titulo = "Pacote Completo - Ilhas Faroé",
                    Descricao = "Pacote de viagem completo para as Ilhas Faroé. Inclui estadia, voo e guia.",
                    ImagemUrl = "/img/ilhasfaroe.jpg"
                },
                new Pacote
                {
                    Id = 8,
                    PrecoPorNoite = 150,
                    Titulo = "Pacote Completo - Hotel Pedra do Monte",
                    Descricao = "Pacote de viagem completo para Londres. Inclui estadia, voo e guia.",
                    ImagemUrl = "/img/londres.jpg"
                }
            );
            builder.Entity<PeriodoIndisponivel>().HasData(
                new PeriodoIndisponivel
                {
                    Id = 1,
                    DataInicio = new DateTime(2026, 07, 10),
                    DataFim = new DateTime(2026, 07, 30),
                    PacoteId = 7
                },
                new PeriodoIndisponivel
                {
                    Id = 2,
                    DataInicio = new DateTime(2026, 08, 10),
                    DataFim = new DateTime(2026, 08, 30),
                    PacoteId = 8
                }
            );
        }
    }
}
