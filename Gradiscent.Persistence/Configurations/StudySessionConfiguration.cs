using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class StudySessionConfiguration : IEntityTypeConfiguration<StudySession>
    {
        public void Configure(EntityTypeBuilder<StudySession> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(s => s.SubjectId)
                .IsRequired();

            builder.Property(s => s.StartTime)
                .IsRequired();

            builder.Property(s => s.EndTime)
                .IsRequired(false);

            builder.Property(s => s.TotalSeconds)
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(s => s.CreatedAt)
                .IsRequired();

            builder.HasOne<Subject>()
                .WithMany()
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(s => s.UserId);
            builder.HasIndex(s => s.SubjectId);

        }
    }
}
