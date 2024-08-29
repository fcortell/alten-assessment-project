using alten_assessment_project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace alten_assessment_project.Infrastructure.Persistence.Configuration
{
    public class LinksConfiguration : IEntityTypeConfiguration<Link>
    {

        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Id)
                    .IsRequired();
            builder.HasIndex(u => u.Id);

            builder.Property(u => u.PreviousEpisodeId).HasColumnName("PreviousEpisodeId");
            builder.HasIndex(u => u.PreviousEpisodeId);

            builder.Property(u => u.NextEpisodeId).HasColumnName("NextEpisodeId");
            builder.HasIndex(u => u.NextEpisodeId);

        }
    }
}