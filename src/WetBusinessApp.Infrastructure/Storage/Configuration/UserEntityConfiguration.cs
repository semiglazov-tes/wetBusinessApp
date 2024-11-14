using Microsoft.EntityFrameworkCore;
using WetBusinessApp.Infrastructure.Storage.Entity;

namespace WetBusinessApp.Infrastructure.Storage.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.UserEmail).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
        }
    }
}
