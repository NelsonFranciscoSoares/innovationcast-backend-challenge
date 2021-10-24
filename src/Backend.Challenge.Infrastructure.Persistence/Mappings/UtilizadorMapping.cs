using Backend.Challenge.Domain.Entities;
using Backend.Challenge.Kernel.Domain.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Challenge.Infrastructure.Persistence.Mappings
{
    public class UtilizadorMapping : BaseEntityTypeConfiguration<UtilizadorEntity>
    {
        public override void Configure(EntityTypeBuilder<UtilizadorEntity> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Username)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(p => p.Email)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

            builder.ToTable("Utilizadores");
        }
    }
}
