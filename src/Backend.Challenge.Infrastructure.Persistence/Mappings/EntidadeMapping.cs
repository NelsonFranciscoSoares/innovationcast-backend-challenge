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
    public class EntidadeMapping : BaseEntityTypeConfiguration<EntidadeEntity>
    {
        public override void Configure(EntityTypeBuilder<EntidadeEntity> builder)
        {
            base.Configure(builder);

            builder.HasMany(f => f.Comentarios)
                    .WithOne(p => p.Entidade)
                    .HasForeignKey(p => p.EntidadeId);

            builder.Property(f => f.TipoComentario)
                    .HasConversion<string>();

            builder.ToTable("Entidades");
        }
    }
}
