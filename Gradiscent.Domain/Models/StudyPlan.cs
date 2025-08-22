using Gradiscent.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradiscent.Domain.Models
{
    [Table("study_plan")]
    public class StudyPlan
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("student_id")]
        public string StudentId { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("day_name")]
        public Day DayName { get; set; } 
        [Column("is_completed",TypeName ="boolean")]
        public bool IsCompleted { get; set; } // Indicates if the study plan for the day is completed
        [Column("created_at", TypeName = "timestamptz")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at", TypeName = "timestamptz")]
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        [ForeignKey("StudentId")]
        public ApplicationUser Student { get; set; } // Navigation property to the student
        public ICollection<StudyPlanSubject> StudyPlanSubjects { get; set; } = new List<StudyPlanSubject>();
    }
}
