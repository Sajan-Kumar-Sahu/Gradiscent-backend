using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class StudyPlanExceptionConfiguration : IEntityTypeConfiguration<StudyPlanException>
    {
        public void Configure(EntityTypeBuilder<StudyPlanException> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.StudyPlanId)
                .IsRequired();

            builder.Property(s => s.IsCancelled)
                .IsRequired();

            builder.Property(s => s.IsAdded)
                .IsRequired();

            builder.Property(s => s.Reason)
                .HasMaxLength(250)
                .IsRequired(false);

            builder.Property(s => s.CreatedAt)
                .IsRequired();

            builder.HasOne<StudyPlan>()
                .WithMany()
                .HasForeignKey(s => s.StudyPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(s => new { s.StudyPlanId, s.Date })
                .IsUnique();
        }
    }
}
