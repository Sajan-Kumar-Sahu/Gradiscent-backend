using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.Roadmaps.DTOs
{
    public class CreateFromRoadmapDto
    {
        public Guid RoadmapId { get; set; }
        public Guid? ParentEntityId { get; set; }  
    }
}
