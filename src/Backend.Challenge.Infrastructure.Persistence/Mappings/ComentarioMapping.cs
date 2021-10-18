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
    public class ComentarioMapping : BaseEntityTypeConfiguration<ComentarioEntity>
    {
        public override void Configure(EntityTypeBuilder<ComentarioEntity> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Autor)
                    .IsRequired()
                    .HasMaxLength(200);
                    
            builder.Property(p => p.Texto)
                    .IsRequired()
                    .HasMaxLength(5000);

            builder.Property(p => p.DataPublicacao)
                    .IsRequired();

            builder.ToTable("Comentarios");
        }
    }
}
