namespace Gradiscent.Application.Timetables.DTOs
{
    public class DailyTimetableResponseDto
    {
        public string Day { get; set; }
        public List<TimetableEntryResponseDto> Entries { get; set; } = new();
    }
}
