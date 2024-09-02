using alten_assessment_project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace alten_assessment_project.Infrastructure.Persistence.Configuration
{
    internal class SchedulesConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property(u => u.Id).HasColumnName("Id");
            builder.Property(u => u.Id)
                    .IsRequired();
            builder.HasIndex(u => u.Id);

            builder.Property(u => u.Time).HasColumnName("Time");
            builder.Property(u => u.Time)
                    .IsRequired();
            builder.HasIndex(u => u.Time);

            builder.Property(u => u.Days).HasColumnName("Days");
            builder.Property(u => u.Days)
                    .IsRequired();
            builder.HasIndex(u => u.Days);
        }
    }
}