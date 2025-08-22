using Gradiscent.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradiscent.Domain.Models
{
    [Table("app_user")]
    public class ApplicationUser:IdentityUser
    {
        [Column("name", TypeName = "text")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Column("avatar_url", TypeName = "text")]
        public string Avatar { get; set; }

        [Column("created_at", TypeName = "timestamptz")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamptz")]
        public DateTime UpdatedAt { get; set; }

        [Column("last_login", TypeName = "timestamptz")]
        public DateTime? LastLogin { get; set; }

        [Column("status")]
        public UserStatus? Status { get; set; }

        // Navigation properties
        public ICollection<StudyPlan> StudyPlans { get; set; } = new List<StudyPlan>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<Streak> Streaks { get; set; } = new List<Streak>();
    }
}
