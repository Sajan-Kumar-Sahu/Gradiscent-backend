namespace Gradiscent.Domain.Entities
{
    public class Streak
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }

        public DateTime? LastActiveDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
