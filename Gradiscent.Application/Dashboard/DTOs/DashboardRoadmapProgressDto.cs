namespace Gradiscent.Application.Dashboard.DTOs
{
    public class DashboardRoadmapProgressDto
    {
        public Guid RoadmapId { get; set; }
        public string Goal { get; set; }

        public int CompletedItems { get; set; }
        public int TotalItems { get; set; }

        public int ProgressPercentage { get; set; }
        public int EstimatedDaysToFinish { get; set; }
    }
}
