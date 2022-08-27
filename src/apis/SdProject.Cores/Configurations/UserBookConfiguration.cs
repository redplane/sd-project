using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SdProject.Core.Configurations
{
    public class UserBookConfiguration : IEntityTypeConfiguration<UserBookEntity>
    {
        public void Configure(EntityTypeBuilder<UserBookEntity> builder)
        {
            // configure the model.
            builder.ToTable("USERBOOK");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.BookId).HasColumnName("BookId");

            builder.HasOne(x => x.User).WithMany(x => x.UserBooks).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book).WithMany(x => x.UserBooks).HasForeignKey(x => x.UserId);
        }
    }
}
