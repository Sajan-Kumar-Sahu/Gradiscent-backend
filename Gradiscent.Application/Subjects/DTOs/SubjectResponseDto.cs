namespace Gradiscent.Application.Subjects.DTOs
{
    public class SubjectResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int OrderIndex { get; set; }
        public int ProgressPercentage { get; set; }
    }
}
