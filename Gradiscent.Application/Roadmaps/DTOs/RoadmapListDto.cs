namespace Gradiscent.Application.Roadmaps.DTOs
{
    public class RoadmapListDto
    {
        public Guid Id { get; set; }
        public string Goal { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
