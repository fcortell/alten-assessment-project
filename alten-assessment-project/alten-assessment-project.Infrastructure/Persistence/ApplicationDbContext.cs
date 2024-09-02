using alten_assessment_project.Domain.Entities;
using alten_assessment_project.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace alten_assessment_project.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Show> Shows { get; set; } = null!;
        public DbSet<Episode> Episodes { get; set; } = null!;
        public DbSet<External> Externals { get; set; } = null!;
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<Link> Links { get; set; } = null!;
        public DbSet<Network> Networks { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;

        public DbSet<WebChannel> WebChannels { get; set; }
        public DbSet<Self> Selfs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ShowConfiguration());
            builder.ApplyConfiguration(new EpisodeConfiguration());
            builder.ApplyConfiguration(new ExternalsConfiguration());
            builder.ApplyConfiguration(new ImagesConfiguration());
            builder.ApplyConfiguration(new LinksConfiguration());
            builder.ApplyConfiguration(new NetworksConfiguration());
            builder.ApplyConfiguration(new RatingConfiguration());
            builder.ApplyConfiguration(new SchedulesConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new WebChannelConfiguration());
            builder.ApplyConfiguration(new SelfConfiguration());

        }
    }
}
