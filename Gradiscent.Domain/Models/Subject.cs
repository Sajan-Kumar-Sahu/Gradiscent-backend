using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradiscent.Domain.Models
{
    [Table("subject")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("student_id")]
        public string StudentId { get; set; }
        [Column("name", TypeName = "text")]
        [Required(ErrorMessage = "Subject name is required")]
        public string Name { get; set; }
        [Column("created_at", TypeName = "timestamptz")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("StudentId")]
        public ApplicationUser Student { get; set; } // Navigation property to the student (ApplicationUser)
        public ICollection<StudyPlanSubject> StudyPlanSubjects { get; set; } = new List<StudyPlanSubject>(); // Collection of study plan subjects associated with this subject
        public ICollection<Topic> Topics { get; set; } = new List<Topic>(); // Collection of topics associated with this subject

    }
}
