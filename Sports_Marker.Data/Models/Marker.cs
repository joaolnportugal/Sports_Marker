using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sports_Marker.Data.Models.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports_Marker.Data.Models
{
    public class Marker : EntityBase
    {
        [Required]
        public string team { get; set; }
        [Required]
        public Color teamColor { get; set; }
        public int fouls { get; set; }
        public int goals { get; set; }
        public bool inGame { get; set; }


    }

    public class MarkerConfiguration : EntityBaseConfiguration<Marker>
    {
        public override void Configure(EntityTypeBuilder<Marker> builder)
        {
            base.Configure(builder);

            

            builder.Property(x => x.team)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.teamColor)
                .HasDefaultValue(Color.Yellow)
                .IsRequired();

            builder.Property(x => x.fouls)
               .HasDefaultValue(0)
               .IsRequired();

            builder.Property(x => x.goals)
               .HasDefaultValue(0)
               .IsRequired();

            builder.Property(x => x.inGame)
                .HasDefaultValue(true)
                .IsRequired();

            //builder.Property(x => x.Id)
            //   .IsRequired();


        }
    }
}
