using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class RoadmapItemConfiguration : IEntityTypeConfiguration<RoadmapItem>
    {
        public void Configure(EntityTypeBuilder<RoadmapItem> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.RoadmapId)
                   .IsRequired();

            builder.Property(r => r.ParentId)
                   .IsRequired(false);

            builder.Property(r => r.Title)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(r => r.ItemType)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(r => r.EstimatedMinutes)
                   .IsRequired(false);

            builder.Property(r => r.Priority)
                   .IsRequired(false);

            builder.Property(r => r.OrderIndex)
                   .IsRequired();

            builder.Property(r => r.Status)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(r => r.CreatedAt)
                   .IsRequired();

            builder.Property(r => r.UpdatedAt)
                   .IsRequired();

            builder.HasOne<Roadmap>()
                   .WithMany()
                   .HasForeignKey(r => r.RoadmapId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<RoadmapItem>()
                   .WithMany()
                   .HasForeignKey(r => r.ParentId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(r => r.RoadmapId);
        }
    }
}
