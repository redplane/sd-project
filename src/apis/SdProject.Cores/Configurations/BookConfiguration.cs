using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SdProject.Core.Entities;

namespace SdProject.Core.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Category);
            builder.Property(x => x.Description);
            builder.Property(x => x.Price);

            builder.HasKey(x => x.Id);
        }
    }
}