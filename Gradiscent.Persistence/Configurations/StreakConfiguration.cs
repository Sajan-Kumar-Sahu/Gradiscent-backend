using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class StreakConfiguration : IEntityTypeConfiguration<Streak>
    {
        public void Configure(EntityTypeBuilder<Streak> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.UserId)
                   .IsRequired()
                   .HasMaxLength(450);

            builder.Property(s => s.CurrentStreak)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.Property(s => s.LongestStreak)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.Property(s => s.LastActiveDate)
                   .IsRequired(false);

            builder.Property(s => s.CreatedAt)
                   .IsRequired();

            builder.Property(s => s.UpdatedAt)
                   .IsRequired();

            builder.HasIndex(s => s.UserId)
                   .IsUnique();
        }
    }
}
