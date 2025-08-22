using Gradiscent.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradiscent.Domain.Models
{
    [Table("study_plan_subject")]
    public class StudyPlanSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("study_plan_id")]
        public int StudyPlanId { get; set; }
        [Column("subject_id")]
        public int SubjectId { get; set; }
        [Column("planned_duration")]
        public int PlannedDuration { get; set; }
        [Column("actual_duration")]
        public int ActualDuration { get; set; }
        [Column("is_completed", TypeName ="boolean")]
        public bool IsCompleted { get; set; }
        [Column("timer_status")]
        public TStatus TimerStatus { get; set; }
        [Column("start_time", TypeName = "timestamptz")]
        public DateTime? StartTime { get; set; }
        [Column("end_time", TypeName = "timestamptz")]
        public DateTime? EndTime { get; set; }
        [Column("created_at", TypeName = "timestamptz")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at", TypeName = "timestamptz")]
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("StudyPlanId")]
        public StudyPlan StudyPlan { get; set; } // Navigation property to StudyPlan
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; } // Navigation property to Subject
        public ICollection<StudyTimerLog> StudyTimerLogs { get; set; } = new List<StudyTimerLog>(); // Collection of timer logs for this subject study plan

    }
}
