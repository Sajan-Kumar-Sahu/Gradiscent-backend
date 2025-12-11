using Gradiscent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gradiscent.Persistence.Configurations
{
    public class SubtopicConfiguration : IEntityTypeConfiguration<Subtopic>
    {
        public void Configure(EntityTypeBuilder<Subtopic> builder)
        {
            builder.HasKey(st => st.Id);

            builder.Property(st => st.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(st => st.TopicId)
                .IsRequired();

            builder.Property(st => st.OrderIndex)
                .IsRequired();

            builder.Property(st => st.IsCompleted)
                .HasDefaultValue(false);

            builder.Property(st => st.CreatedAt)
                .IsRequired();

            builder.Property(st => st.UpdatedAt)
                .IsRequired();
        }
    }
}
