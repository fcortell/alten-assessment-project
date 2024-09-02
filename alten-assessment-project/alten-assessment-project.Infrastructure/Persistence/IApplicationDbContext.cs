using alten_assessment_project.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace alten_assessment_project.Infrastructure.Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<Show> Shows { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<External> Externals { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}