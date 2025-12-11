using Gradiscent.Domain.Enums;

namespace Gradiscent.Domain.Entities
{
    public class StudyPlanSchedule
    {
        public Guid Id { get; set; }
        public Guid StudyPlanId { get; set; }
        public ReccurenceType ReccurenceType { get; set; }

        public int? DaysOfWeekMask { get; set; }
        public int? IntervalDays { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
