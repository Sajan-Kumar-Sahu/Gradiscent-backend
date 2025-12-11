namespace Gradiscent.Application.Dashboard.DTOs
{
    public class DashboardTopicSummaryDto
    {
        public Guid TopicId { get; set; }
        public string TopicName { get; set; }

        public int ProgressPercentage { get; set; }
        public int MinutesStudied { get; set; }
    }
}
