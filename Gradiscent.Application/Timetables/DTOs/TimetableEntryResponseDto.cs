namespace Gradiscent.Application.Timetables.DTOs
{
    public class TimetableEntryResponseDto
    {
        public Guid Id { get; set; }

        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

        public Guid? TopicId { get; set; }
        public string? TopicName { get; set; }

        public string DayOfWeek { get; set; }
        public int DurationMinutes { get; set; }

        public bool IsCompletedForToday { get; set; }
        public int MinutesStudiedToday { get; set; }
    }
}
