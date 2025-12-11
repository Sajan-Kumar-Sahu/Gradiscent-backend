using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.StudyPlans.DTOs
{
    public class CreateStudyPlanExceptionDto
    {
        public DateTime Date { get; set; }
        public string? Reason { get; set; }
    }
}
