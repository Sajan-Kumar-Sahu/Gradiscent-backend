namespace Gradiscent.Application.Timetables.DTOs
{
    public class WeeklyTimetableResponseDto
    {
        public List<DailyTimetableResponseDto> Days { get; set; } = new();
    }
}
