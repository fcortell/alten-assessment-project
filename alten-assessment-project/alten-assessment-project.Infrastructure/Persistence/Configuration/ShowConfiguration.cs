using alten_assessment_project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace alten_assessment_project.Infrastructure.Persistence.Configuration
{
    public class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Id)
                    .IsRequired();
            builder.HasIndex(u => u.Id);

            builder.Property(u => u.Name).HasColumnName("Name");
            builder.Property(u => u.Name)
                    .IsRequired();
            builder.HasIndex(u => u.Name);


        }
    }
}