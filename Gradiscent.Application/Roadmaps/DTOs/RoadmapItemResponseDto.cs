using Gradiscent.Domain.Enums;

namespace Gradiscent.Application.Roadmaps.DTOs
{
    public class RoadmapItemResponseDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }

        public string Title { get; set; }

        public RoadmapItemType ItemType { get; set; }
        public RoadmapItemStatus Status { get; set; }

        public int? EstimatedMinutes { get; set; }
        public int? Priority { get; set; }

        public int OrderIndex { get; set; }

        public List<RoadmapItemResponseDto> Children { get; set; } = new();
    }
}
