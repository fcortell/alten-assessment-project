using alten_assessment_project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace alten_assessment_project.Infrastructure.Persistence.Configuration
{
    public class ExternalsConfiguration : IEntityTypeConfiguration<External>
    {

        public void Configure(EntityTypeBuilder<External> builder)
        {
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Id)
                    .IsRequired();
            builder.HasIndex(u => u.Id);

            builder.Property(u => u.Tvrage).HasColumnName("Tvrage");
            builder.Property(u => u.Tvrage)
                    .IsRequired();
            builder.HasIndex(u => u.Tvrage);

            builder.Property(u => u.Thetvdb).HasColumnName("Thetvdb");
            builder.Property(u => u.Thetvdb)
                    .IsRequired();
            builder.HasIndex(u => u.Thetvdb);

            builder.Property(u => u.Imdb).HasColumnName("Imdb");
            builder.Property(u => u.Imdb)
                    .IsRequired();
            builder.HasIndex(u => u.Imdb);
        }

    }
}