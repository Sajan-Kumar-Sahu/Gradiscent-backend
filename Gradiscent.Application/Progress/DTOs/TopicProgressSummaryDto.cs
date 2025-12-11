using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.Progress.DTOs
{
    public class TopicProgressSummaryDto
    {
        public Guid TopicId { get; set; }
        public string TopicName { get; set; }

        public int CompletedSubtopics { get; set; }
        public int TotalSubtopics { get; set; }
        public int ProgressPercentage { get; set; }
    }
}
