using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradiscent.Domain.Models
{
    [Table("study_timer_log")]
    public class StudyTimerLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("study_plan_subject_id")]
        public int StudyPlanSubjectId { get; set; }
        [Column("start_time", TypeName = "timestamptz")]
        public DateTime StartTime { get; set; }
        [Column("end_time", TypeName = "timestamptz")]
        public DateTime EndTime { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("duration")]
        public int Duration { get; private set; }
        [Column("created_at", TypeName ="timestamptz")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at", TypeName ="timestamptz")]
        public DateTime UpdatedAt { get; set; } // Timestamp when the log was last updated

        // Navigation property
        [ForeignKey("StudyPlanSubjectId")]
        public StudyPlanSubject StudyPlanSubject { get; set; } // Navigation property to the associated StudyPlanSubject
    }
}
