using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class StudentPlanScheduleConfiguration:IEntityTypeConfiguration<StudyPlanSchedule>
    {
        public void Configure(EntityTypeBuilder<StudyPlanSchedule> builder)
        {
            builder.HasKey(sps => sps.Id);

            builder.Property(sps => sps.ReccurenceType)
                .IsRequired();

            builder.Property(sps => sps.DaysOfWeekMask)
                .IsRequired(false);

            builder.Property(sps => sps.IntervalDays)
                .IsRequired(false);

            builder.Property(sps => sps.StartDate)
                .IsRequired(false);

            builder.Property(sps => sps.EndDate)
                .IsRequired(false);

            builder.Property(sps => sps.CreatedAt)
                .IsRequired();

            builder.Property(sps => sps.UpdatedAt)
                .IsRequired();

            builder.HasOne<StudyPlan>()
                .WithMany()
                .HasForeignKey(sps => sps.StudyPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(sps => sps.StudyPlanId);
        }
    }
}
