using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class StudyPlanConfiguration : IEntityTypeConfiguration<StudyPlan>
    {
        public void Configure(EntityTypeBuilder<StudyPlan> builder)
        {
            builder.HasKey(sp => sp.Id);

            builder.Property(sp => sp.UserId)
                .IsRequired()
                .HasMaxLength(450);

            builder.Property(sp => sp.SubjectId)
                .IsRequired();

            builder.Property(sp => sp.RequiredMinutes)
                .IsRequired();

            builder.Property(sp => sp.EffectiveFrom)
                .IsRequired(false);

            builder.Property(sp => sp.EffectiveTo)
                .IsRequired(false);

            builder.HasIndex(sp => new { sp.UserId, sp.SubjectId })
                .IsUnique();

            builder.HasOne<Subject>()
                .WithMany()
                .HasForeignKey(sp => sp.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
