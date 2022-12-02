using DemoWebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Data
{
    public class DemoAPIDbContext : DbContext
    {
        public DemoAPIDbContext(DbContextOptions<DemoAPIDbContext> options) : base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

    }
}
