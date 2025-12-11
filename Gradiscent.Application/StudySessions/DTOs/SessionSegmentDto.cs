using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.StudySessions.DTOs
{
    public class SessionSegmentDto
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DurationMinutes { get; set; }
    }
}
