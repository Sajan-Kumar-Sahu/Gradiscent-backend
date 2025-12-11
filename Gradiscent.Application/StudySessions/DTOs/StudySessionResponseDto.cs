using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Application.StudySessions.DTOs
{
    public class StudySessionResponseDto
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }

        public Guid? TopicId { get; set; }
        public string? TopicName { get; set; }

        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        public bool IsActive { get; set; }

        public List<SessionSegmentDto> Segments { get; set; } = new();
        public int TotalMinutesStudied { get; set; }
    }
}
