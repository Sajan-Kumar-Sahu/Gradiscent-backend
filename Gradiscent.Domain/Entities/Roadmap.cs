namespace Gradiscent.Domain.Entities
{
    public class Roadmap
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public string Goal { get; set; }
        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
