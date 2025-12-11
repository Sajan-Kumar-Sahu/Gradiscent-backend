using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class SessionSegmentConfiguration : IEntityTypeConfiguration<SessionSegment>
    {
        public void Configure(EntityTypeBuilder<SessionSegment> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.StudySessionId)
                .IsRequired();

            builder.Property(s => s.StartTime)
                .IsRequired();

            builder.Property(s => s.EndTime)
                .IsRequired(false);

            builder.Property(s => s.DurationSeconds)
                .IsRequired()
                .HasDefaultValue(0);

            builder.HasOne<StudySession>()
                .WithMany()
                .HasForeignKey(s => s.StudySessionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(s => s.StudySessionId);

        }
    }
}
