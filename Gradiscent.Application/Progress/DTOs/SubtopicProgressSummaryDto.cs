namespace Gradiscent.Application.Progress.DTOs
{
    public class SubtopicProgressSummaryDto
    {
        public Guid SubtopicId { get; set; }
        public string SubtopicName { get; set; }

        public bool IsCompleted { get; set; }
    }
}
