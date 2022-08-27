using Core.Entities;
using Microsoft.EntityFrameworkCore;
using SdProject.Core.Configurations;

namespace SdProject.Core.DbContexts
{
    public class SdPDbContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<BookEntity> Book { get; set; }
        public DbSet<UserBookEntity> UserBookEntities { get; set; }
        public SdPDbContext(DbContextOptions<SdPDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserBookConfiguration());
        }
    }
}
