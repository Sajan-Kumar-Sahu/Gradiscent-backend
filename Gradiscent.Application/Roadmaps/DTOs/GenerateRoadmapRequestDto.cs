namespace Gradiscent.Application.Roadmaps.DTOs
{
    public class GenerateRoadmapRequestDto
    {
        public string Goal { get; set; }
        public string? Description { get; set; }
        public int? TargetDurationWeeks { get; set; }
    }
}
