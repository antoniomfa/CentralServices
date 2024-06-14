using CentralService.DataAccess.Models;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralService.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt) : base(opt)
        {
                
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Community> Communities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                .HasMany(x => x.Communities)
                .WithOne(x => x.Platform!)
                .HasForeignKey(x => x.Platform.Id);

            modelBuilder.Entity<Community>()
                .HasOne(x => x.Platform)
                .WithMany(x => x.Communities)
                .HasForeignKey(x => x.PlatformId);
        }
    }
}
