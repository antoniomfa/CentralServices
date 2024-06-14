using CentralService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralService.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt) : base(opt)
        {
                
        }

        public DbSet<Platform> Platforms { get; set; }        
    }
}
