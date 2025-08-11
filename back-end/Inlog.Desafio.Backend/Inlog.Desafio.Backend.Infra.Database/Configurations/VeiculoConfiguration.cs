using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlog.Desafio.Backend.Domain.Models.Veiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inlog.Desafio.Backend.Infra.Database.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> veiculo)
        {
           veiculo.HasKey(v => v.Id);

            veiculo.HasOne(v => v.Localizacao)
              .WithOne(l => l.Veiculo)
              .HasForeignKey<Localizacao>(l => l.IdVeiculo)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}