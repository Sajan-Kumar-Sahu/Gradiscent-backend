using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gradiscent.Persistence.Configurations
{
    public class RoadmapConfiguration : IEntityTypeConfiguration<Roadmap>
    {
        public void Configure(EntityTypeBuilder<Roadmap> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserId)
                   .IsRequired()
                   .HasMaxLength(450);

            builder.Property(r => r.Goal)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(r => r.Description)
                   .HasMaxLength(1000)
                   .IsRequired(false);

            builder.Property(r => r.IsActive)
                   .IsRequired();

            builder.Property(r => r.CreatedAt)
                   .IsRequired();

            builder.Property(r => r.UpdatedAt)
                   .IsRequired();

            builder.HasIndex(r => r.UserId);
        }
    }
}
