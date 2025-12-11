using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Persistence.Configurations
{
    public class MergeMappingConfiguration : IEntityTypeConfiguration<MergeMapping>
    {
        public void Configure(EntityTypeBuilder<MergeMapping> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.RoadmapItemId)
                   .IsRequired();

            builder.Property(m => m.EntityType)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(m => m.EntityId)
                   .IsRequired();

            builder.Property(m => m.CreatedAt)
                   .IsRequired();

            builder.HasOne<RoadmapItem>()
                   .WithMany()
                   .HasForeignKey(m => m.RoadmapItemId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(m => m.RoadmapItemId);

            builder.HasIndex(m => m.EntityId).IsUnique(false);
        }
    }
}
