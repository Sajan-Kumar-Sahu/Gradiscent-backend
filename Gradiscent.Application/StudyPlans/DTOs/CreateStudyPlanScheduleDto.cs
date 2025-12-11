using Gradiscent.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.StudyPlans.DTOs
{
    public class CreateStudyPlanScheduleDto
    {
        public Guid SubjectId { get; set; }
        public Weekday? DayOfWeek { get; set; }   // null allowed for daily
        public int DurationMinutes { get; set; }
    }
}
