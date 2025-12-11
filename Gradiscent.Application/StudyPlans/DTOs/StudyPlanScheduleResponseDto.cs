using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.StudyPlans.DTOs
{
    public class StudyPlanScheduleResponseDto
    {
        public Guid Id { get; set; }

        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

        public string? DayOfWeek { get; set; }

        public int DurationMinutes { get; set; }
    }
}
