using Gradiscent.Domain.Enums;

namespace Gradiscent.Domain.Entities
{
    public class TimetableEntry
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid SubjectId { get; set; }

        public Weekday DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
