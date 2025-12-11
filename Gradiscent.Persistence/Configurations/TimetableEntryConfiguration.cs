using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class TimetableEntryConfiguration : IEntityTypeConfiguration<TimetableEntry>
    {
        public void Configure(EntityTypeBuilder<TimetableEntry> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(t => t.SubjectId)
                .IsRequired();

            builder.Property(t => t.DayOfWeek)
                .IsRequired();

            builder.Property(t => t.StartTime)
                .IsRequired();

            builder.Property(t => t.EndTime)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .IsRequired();

            builder.Property(t => t.UpdatedAt)
                .IsRequired();

            builder.HasOne<Subject>()
                .WithMany()
                .HasForeignKey(t => t.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(t => new { t.UserId, t.DayOfWeek, t.StartTime });
        }
    }
}
