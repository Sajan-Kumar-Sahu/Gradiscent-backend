using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gradiscent.Domain.Models
{
    [Table("TopicDayTags")]
    public class TopicDayTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("topic_id")]
        public int TopicId { get; set; }
        [Column("date", TypeName = "date")]
        public DateOnly Date { get; set; }
        [Column("created_at", TypeName = "timestamptz")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; } // Navigation property to the associated Topic
    }
}
