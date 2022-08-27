using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SdProject.Core.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            // configure the model.
            builder.ToTable("book");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.Category).HasColumnName("Category");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Price).HasColumnName("Price");
        }
    }
}
