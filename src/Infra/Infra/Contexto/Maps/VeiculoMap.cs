using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Contexto.Maps
{
    class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Marca).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Quilometragem).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
            builder.Property(x => x.Ano).IsRequired().HasColumnType("DATE");
        }
    }
}
