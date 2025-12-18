using Gradiscent.Domain.Entities;
using Gradiscent.Persistence.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Token)
                .IsRequired();

            builder.Property(e => e.ExpiresAt)
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(e => e.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.Token)
                .IsUnique();
        }
    }
}
