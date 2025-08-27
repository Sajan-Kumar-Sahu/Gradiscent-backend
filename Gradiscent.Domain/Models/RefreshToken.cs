using System.ComponentModel.DataAnnotations.Schema;

namespace Gradiscent.Domain.Models
{
    [Table("refresh_token")]
    public class RefreshToken
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("token", TypeName = "text")]
        public string Token { get; set; }

        [Column("expires", TypeName = "timestamptz")]
        public DateTime Expires { get; set; }

        [NotMapped]
        public bool IsExpired => DateTime.UtcNow >= Expires;

        [Column("created_at", TypeName = "timestamptz")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by_ip", TypeName = "text")]
        public string CreatedByIp { get; set; }

        [Column("revoked", TypeName = "timestamptz")]
        public DateTime? Revoked { get; set; }

        [Column("revoked_by_ip", TypeName = "text")]
        public string? RevokedByIp { get; set; }

        [Column("replaced_by_token", TypeName = "text")]
        public string? ReplacedByToken { get; set; }

        // Link to ApplicationUser
        [Column("user_id")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
