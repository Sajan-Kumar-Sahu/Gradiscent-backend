namespace Gradiscent.Application.Subjects.DTOs
{
    public class TopicResponseDto
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        public int OrderIndex { get; set; }
        public int ProgressPercentage { get; set; }
    }
}
