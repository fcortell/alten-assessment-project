using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace alten_assessment_project.Infrastructure.Persistence.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Id)
                    .IsRequired();
            builder.HasIndex(u => u.Id);

            builder.Property(u => u.Name).HasColumnName("Name");
            builder.Property(u => u.Name)
                    .IsRequired();
            builder.HasIndex(u => u.Name);

            builder.Property(u => u.ShowId).HasColumnName("ShowId");
            builder.Property(u => u.ShowId)
                    .IsRequired();
            builder.HasIndex(u => u.ShowId);
        }
    }
}
