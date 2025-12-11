using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.Dashboard.DTOs
{
    public class DashboardStreakSummaryDto
    {
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public bool StreakActiveToday { get; set; }
    }
}
