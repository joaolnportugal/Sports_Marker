using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Marker.Data.Models
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset Now { get; set; }
        public DateTimeOffset Diference{ get; set; }
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

            builder.Property(x => x.Now)
              .HasDefaultValueSql("Now()")
              .ValueGeneratedOnAdd()
              .IsRequired();

            builder.Property(x => x.Diference)
              .HasDefaultValueSql("DATEPART(mi, Now - Start)")
              .ValueGeneratedOnAdd()
              .IsRequired();
        }
    }
}
