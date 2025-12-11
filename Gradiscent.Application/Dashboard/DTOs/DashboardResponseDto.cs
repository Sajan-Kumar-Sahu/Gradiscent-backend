namespace Gradiscent.Application.Dashboard.DTOs
{
    public class DashboardResponseDto
    {
        public DashboardStreakSummaryDto Streak { get; set; }
        public DashboardSessionDto ActiveSession { get; set; }

        public List<DashboardTimetableEntryDto> TodayTimetable { get; set; } = new();

        public List<DashboardSubjectSummaryDto> Subjects { get; set; } = new();

        public DashboardRoadmapProgressDto RoadmapProgress { get; set; }

        public DashboardWeekStatsDto WeekStats { get; set; }
    }
}
