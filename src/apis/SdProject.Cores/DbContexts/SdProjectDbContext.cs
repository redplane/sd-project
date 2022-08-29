using Microsoft.EntityFrameworkCore;
using SdProject.Core.Configurations;
using SdProject.Core.Entities;

namespace SdProject.Core.DbContexts
{
    public class SdProjectDbContext : DbContext
    {
        public SdProjectDbContext(DbContextOptions<SdProjectDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserBookConfiguration());
        }
    }
}