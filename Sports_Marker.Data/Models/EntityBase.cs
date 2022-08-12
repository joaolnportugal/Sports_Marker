using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Marker.Data.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset Stop { get; set; }
        public DateTimeOffset Restart { get; set; }

    }

    public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
      where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Start)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Stop)
              .HasDefaultValueSql("GETUTCDATE()")
              .ValueGeneratedOnAdd()
              .IsRequired();

            builder.Property(x => x.Restart)
             .HasDefaultValueSql("GETUTCDATE()")
             .ValueGeneratedOnAdd()
             .IsRequired();


        }
    }
}
