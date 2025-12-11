namespace Gradiscent.Application.Subjects.DTOs
{
    public class UpdateTopicDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? OrderIndex { get; set; }
    }
}
