using Gradiscent.Domain.Enums;

namespace Gradiscent.Domain.Entities
{
    public class RoadmapItem
    {
        public Guid Id { get; set; }
        public Guid RoadmapId { get; set; }
        public Guid? ParentId { get; set; }

        public string Title { get; set; }
        public RoadmapItemType ItemType { get; set; }

        public int? EstimatedMinutes { get; set; }
        public int? Priority { get; set; }
        public int OrderIndex { get; set; }

        public RoadmapItemStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
