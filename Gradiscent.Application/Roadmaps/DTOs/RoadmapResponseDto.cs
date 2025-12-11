namespace Gradiscent.Application.Roadmaps.DTOs
{
    public class RoadmapResponseDto
    {
        public Guid Id { get; set; }
        public string Goal { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<RoadmapItemResponseDto> Items { get; set; } = new();
    }
}
