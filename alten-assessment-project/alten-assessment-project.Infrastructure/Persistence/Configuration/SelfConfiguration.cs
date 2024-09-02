using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace alten_assessment_project.Infrastructure.Persistence.Configuration
{
    public class SelfConfiguration : IEntityTypeConfiguration<Self>
    {
        public void Configure(EntityTypeBuilder<Self> builder)
        {
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Id)
                    .IsRequired();
            builder.HasIndex(u => u.Id);
        }
    }
}
