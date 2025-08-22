using Gradiscent.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradiscent.Domain.Models
{
    [Table("streak")]
    public class Streak
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("student_id")]
        public string StudentId { get; set; }
        [Column("current_streak")]
        public int CurrentStreak { get; set; } 
        [Column("status")]
        public StreakStatus Status { get; set; }
        [Column("last_streak_date", TypeName ="timestamptz")]
        public DateTime LastStreakDate { get; set; }
        [Column("max_streak")]
        public int MaxStreak { get; set; }
        [Column("created_at", TypeName ="timestamptz")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at",TypeName ="timestamptz")]
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        [ForeignKey("StudentId")]
        public ApplicationUser Student { get; set; } // Navigation property to the student (ApplicationUser)
    }
}
