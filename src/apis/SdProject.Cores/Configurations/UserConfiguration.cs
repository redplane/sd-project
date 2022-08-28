using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SdProject.Core.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // configure the model.
            builder.ToTable("user");
            builder.Property(x => x.id).HasColumnName("id");
            builder.Property(x => x.FirstName).HasColumnName("FirstName");
            builder.Property(x => x.LastName).HasColumnName("LastName");
            builder.Property(x => x.Birthdate).HasColumnName("Birthdate");
        }
    }
}
