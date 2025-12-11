namespace Gradiscent.Application.Dashboard.DTOs
{
    public class DashboardWeekStatsDto
    {
        public int TotalMinutesStudied { get; set; }
        public int DaysActiveThisWeek { get; set; }

        public Dictionary<string, int> DailyMinutes { get; set; } = new();  
    }
}
