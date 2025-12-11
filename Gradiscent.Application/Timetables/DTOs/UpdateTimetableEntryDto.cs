using Gradiscent.Domain.Enums;
namespace Gradiscent.Application.Timetables.DTOs
{
    public class UpdateTimetableEntryDto
    {
        public Guid SubjectId { get; set; }
        public Guid? TopicId { get; set; }

        public Weekday DayOfWeek { get; set; }
        public int DurationMinutes { get; set; }
    }
}
