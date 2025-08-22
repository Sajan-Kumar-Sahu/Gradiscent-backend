using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradiscent.Domain.Models
{
    [Table("topics")]
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("subject_id")]
        public int SubjectId { get; set; }
        [Column("name", TypeName = "text")]
        public string Name { get; set; }
        [Column("created_at", TypeName = "timestamptz")]
        public DateTime CreatedAt { get; set; }

        // Navigation property
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; } // Navigation property to the associated Subject
        public ICollection<TopicDayTag> TopicDayTags { get; set; } = new List<TopicDayTag>(); // Collection of topic date tags associated with this topic
    }
}
