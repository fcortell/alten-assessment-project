using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain.Repositories;
using alten_assessment_project.Infrastructure.Persistence;
using alten_assessment_project.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace alten_assessment_project.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<Persistence.ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("Database"));
            }
            else
            {
                services.AddDbContext<Persistence.ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("Database"),
                        options
                        => options.EnableRetryOnFailure()));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddMemoryCache();

            services.AddScoped(typeof(ICountryRepository), typeof(CountryRepository));
            services.AddScoped(typeof(INetworkRepository), typeof(NetworkRepository));
            services.AddScoped(typeof(IRatingRepository), typeof(RatingRepository));
            services.AddScoped(typeof(IScheduleRepository), typeof(ScheduleRepository));
            services.AddScoped(typeof(IShowRepository), typeof(ShowRepository));
            services.AddScoped(typeof(ILinkRepository), typeof(LinkRepository));
            services.AddScoped(typeof(IImageRepository), typeof(ImageRepository));
            services.AddScoped(typeof(IGenreRepository), typeof(GenreRepository));
            services.AddScoped(typeof(IExternalRepository), typeof(ExternalRepository));
            services.AddScoped(typeof(IEpisodeRepository), typeof(EpisodeRepository));

            return services;
        }
    }
}
