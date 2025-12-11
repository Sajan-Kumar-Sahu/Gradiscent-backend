namespace Gradiscent.Application.Subjects.DTOs
{
    public class SubtopicResponseDto
    {
        public Guid Id { get; set; }
        public Guid TopicId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public int OrderIndex { get; set; }
        public bool IsCompleted { get; set; }
    }
}
