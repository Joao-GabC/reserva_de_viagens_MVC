using AgenciaDeViagens.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Pacote>().HasData(
                new Pacote
                {
                    Id = 1,
                    PrecoPorNoite = 270,
                    Titulo = "Pacote Completo - Hotel Traíra Dourada",
                    Descricao = "Pacote para o Hotel Traíra Dourada que inclui café da manhã, almoço e jantar.",
                    ImagemUrl = "/img/trairadourada.jpg"
                },
                new Pacote
                {
                    Id = 2,
                    PrecoPorNoite = 150,
                    Titulo = "Pacote Completo - Hotel Pedra do Monte",
                    Descricao = "Pacote para o Hotel Pedra do Monte que inclui café da manhã, almoço e jantar.",
                    ImagemUrl = "/img/pedradomonte.jpg"
                }
            );
        }
    }
}
