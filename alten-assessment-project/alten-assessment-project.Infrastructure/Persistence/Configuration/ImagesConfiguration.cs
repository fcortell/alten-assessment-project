using alten_assessment_project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace alten_assessment_project.Infrastructure.Persistence.Configuration
{
    internal class ImagesConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Id)
                    .IsRequired();
            builder.HasIndex(u => u.Id);

            builder.Property(u => u.Medium).HasColumnName("Medium");
            builder.Property(u => u.Medium)
                    .IsRequired();
            builder.HasIndex(u => u.Medium);

            builder.Property(u => u.Original).HasColumnName("Original");
            builder.Property(u => u.Original)
                    .IsRequired();
            builder.HasIndex(u => u.Original);

        }
    }
}