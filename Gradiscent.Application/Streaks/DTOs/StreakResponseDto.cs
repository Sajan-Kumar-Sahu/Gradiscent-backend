namespace Gradiscent.Application.Streaks.DTOs
{
    public class StreakResponseDto
    {
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public DateTime? LastActiveDate { get; set; }
        public bool IsStreakActiveToday { get; set; }
    }
}
