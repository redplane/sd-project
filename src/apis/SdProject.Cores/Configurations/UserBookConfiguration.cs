using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SdProject.Core.Entities;

namespace SdProject.Core.Configurations
{
    public class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> builder)
        {
            builder.Property(x => x.Id);
            builder.Property(x => x.UserId);
            builder.Property(x => x.BookId);
            builder.Property(x => x.HaveRead);

            builder.HasIndex(x => new { x.UserId, x.BookId }).IsUnique();
            builder.HasOne(x => x.User).WithMany(x => x.UserBooks).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book).WithMany(x => x.UserBooks).HasForeignKey(x => x.UserId);
        }
    }
}