using Gradiscent.Domain.Entities;
using Gradiscent.Persistence.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Gradiscent.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
         
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Subtopic> Subtopics { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<StudyPlanSchedule> StudyPlanSchedules { get; set; }
        public DbSet<StudyPlanException> StudyPlanExceptions { get; set; }
        public DbSet<StudySession> StudySessions { get; set; }
        public DbSet<SessionSegment> SessionSegments { get; set; }
        public DbSet<TimetableEntry> TimetableEntries { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<RoadmapItem> RoadmapItems { get; set; }
        public DbSet<MergeMapping> MergeMappings { get; set; }
        public DbSet<Streak> Streaks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
