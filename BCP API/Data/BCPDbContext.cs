using BCP_API.Entity;
using Microsoft.EntityFrameworkCore;

namespace BCP_API.Data
{
    public class BCPDbContext : DbContext
    {
        public BCPDbContext(DbContextOptions<BCPDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<MiscTags> MiscTags { get; set; }
        public DbSet<BCPRecords> BCPRecords { get; set; }
        public DbSet<BCPTypes> BCPTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
