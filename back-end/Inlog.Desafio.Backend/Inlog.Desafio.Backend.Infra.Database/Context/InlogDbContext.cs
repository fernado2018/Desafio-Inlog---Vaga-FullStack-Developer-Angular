using System.Data;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Inlog.Desafio.Backend.Infra.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Inlog.Desafio.Backend.Infra.Database.Context
{
    public class InlogDbContext : DbContext
    {
        public InlogDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());
        }
    }
}