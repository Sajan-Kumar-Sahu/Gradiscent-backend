using Gradiscent.Domain.Enums;

namespace Gradiscent.Domain.Entities
{
    public class MergeMapping
    {
        public Guid Id { get; set; }

        public Guid RoadmapItemId { get; set; }
        public RoadmapItemType EntityType { get; set; }

        public Guid EntityId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
