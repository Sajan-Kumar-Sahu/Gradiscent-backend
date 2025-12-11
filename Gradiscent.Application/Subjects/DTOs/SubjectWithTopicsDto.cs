namespace Gradiscent.Application.Subjects.DTOs
{
    public class SubjectWithTopicsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int OrderIndex { get; set; }

        public List<TopicResponseDto> Topics { get; set; } = new();
    }
}
