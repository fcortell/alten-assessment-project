using alten_assessment_project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace alten_assessment_project.Infrastructure.Persistence.Configuration
{
    internal class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {

        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Id)
                    .IsRequired();
            builder.HasIndex(u => u.Id);

        }

    }
}