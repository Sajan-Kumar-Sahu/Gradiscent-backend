namespace Gradiscent.Application.Subjects.DTOs
{
    public class TopicWithSubtopicDto
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public int OrderIndex { get; set; }

        public List<SubtopicResponseDto> Subtopics { get; set; } = new();
    }
}
