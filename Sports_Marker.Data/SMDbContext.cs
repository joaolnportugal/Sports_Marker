using Microsoft.EntityFrameworkCore;
using Sports_Marker.Data.Models;
using System.Reflection;

namespace Sports_Marker.Data
{
    public class SMDbContext : DbContext
    {
        public DbSet<Marker> Markers { get; set; }

        public SMDbContext(DbContextOptions<SMDbContext> dbContextOptions)
            : base(dbContextOptions)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.FullName.StartsWith("Sports_Marker.Data", StringComparison.OrdinalIgnoreCase));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
    }
}
