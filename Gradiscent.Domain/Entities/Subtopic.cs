using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Domain.Entities
{
    public class Subtopic
    {
        public Guid Id { get; set; }
        public Guid TopicId { get; set; }

        public string Name { get; set; }
        public int OrderIndex { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
