using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public string Name { get; set; }
        public int OrderIndex { get; set; }

        public int TotalStudiedMinutes { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
