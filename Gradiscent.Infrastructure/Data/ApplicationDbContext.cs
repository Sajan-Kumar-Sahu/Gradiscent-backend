using Gradiscent.Domain.Enums;
using Gradiscent.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gradiscent.Infrastructure.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<Streak> Streaks { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<StudyPlanSubject> StudyPlanSubjects { get; set; }
        public DbSet<StudyTimerLog> StudyTimerLogs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicDayTag> TopicDayTags { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity=>
            {
                // Map enum to string and set default value
                entity.Property(u => u.Status)
                .HasConversion<string>()
                .HasDefaultValue(UserStatus.PENDING_VERIFICATION);

                //Relationships
                entity.HasMany(u => u.StudyPlans)
                .WithOne(s=> s.Student)
                .HasForeignKey(sp => sp.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.Subjects)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.Streaks)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(u => u.CreatedAt)
                .HasDefaultValueSql("NOW()");
            });

            builder.Entity<Streak>(entity =>
            {
                entity.Property(u => u.Status)
                .HasConversion<string>();

                entity.Property(s => s.CreatedAt)
                .HasDefaultValueSql("NOW()");

                entity.HasOne(s=> s.Student)
                .WithMany(u => u.Streaks)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<StudyPlan>(entity =>
            {
                entity.HasOne(sp => sp.Student)
                .WithMany(u => u.StudyPlans)
                .HasForeignKey(sp => sp.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s => s.StudyPlanSubjects)
                .WithOne(sps => sps.StudyPlan)
                .HasForeignKey(sps => sps.StudyPlanId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(sp => sp.CreatedAt)
                .HasDefaultValueSql("NOW()");

                entity.Property(s=>s.DayName)
                .HasConversion<string>();
            });

            builder.Entity<StudyPlanSubject>(entity =>
            {
                entity.Property(sps => sps.CreatedAt)
                .HasDefaultValueSql("NOW()");

                entity.Property(sps=>sps.TimerStatus)
                .HasConversion<string>();

                entity.HasOne(sps => sps.StudyPlan)
                .WithMany(sp => sp.StudyPlanSubjects)
                .HasForeignKey(sps => sps.StudyPlanId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(sps => sps.Subject)
                .WithMany(s => s.StudyPlanSubjects)
                .HasForeignKey(sps => sps.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(sps => sps.StudyTimerLogs)
                .WithOne(stl => stl.StudyPlanSubject)
                .HasForeignKey(stl => stl.StudyPlanSubjectId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<StudyTimerLog>(entity =>
            {
                entity.HasOne(stl => stl.StudyPlanSubject)
                .WithMany(sps => sps.StudyTimerLogs)
                .HasForeignKey(sps => sps.StudyPlanSubjectId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(stl => stl.CreatedAt)
                .HasDefaultValueSql("NOW()");

                entity.Property(stl => stl.Duration)
                .HasComputedColumnSql("EXTRACT(EPOCH FROM end_time - start_time)::int",stored:true);
            });

            builder.Entity<Subject>(entity =>
            {
                entity.Property(s => s.CreatedAt)
                .HasDefaultValueSql("NOW()");

                entity.HasOne(s => s.Student)
                .WithMany(u => u.Subjects)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s => s.StudyPlanSubjects)
                .WithOne(s => s.Subject)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s=>s.Topics)
                .WithOne(s=>s.Subject)
                .HasForeignKey(s=>s.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Topic>(entity =>
            {
                entity.HasOne(t=>t.Subject)
                .WithMany(t => t.Topics)
                .HasForeignKey(t=>t.SubjectId) 
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(t=>t.TopicDayTags)
                .WithOne(td=>td.Topic)
                .HasForeignKey(td=>td.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(t => t.CreatedAt)
                .HasDefaultValueSql("NOW()");
            });

            builder.Entity<TopicDayTag>(entity =>
            {
                entity.Property(td => td.CreatedAt)
                .HasDefaultValueSql("NOW()");

                entity.HasOne(td=> td.Topic)
                .WithMany(t=> t.TopicDayTags)
                .HasForeignKey(td=> td.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
