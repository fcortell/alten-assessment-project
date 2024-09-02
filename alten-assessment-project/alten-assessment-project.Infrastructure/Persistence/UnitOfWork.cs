using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain;
using alten_assessment_project.Domain.Repositories;

namespace alten_assessment_project.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;
        private readonly ApplicationDbContext _context;

        public IShowRepository Shows { get; }
        public ICountryRepository Countries { get; }
        public IEpisodeRepository Episodes { get; }
        public IExternalRepository Externals { get; }
        public IGenreRepository Genres { get; }
        public IImageRepository Images { get; }
        public ILinkRepository Links { get; }
        public IRatingRepository Ratings { get; }
        public INetworkRepository Networks { get; }
        public IScheduleRepository Schedules { get; }
        public ISelfRepository Selfs { get; }
        public IWebChannelRepository WebChannels { get; }

        public UnitOfWork(ApplicationDbContext context, 
            IShowRepository showRepository, 
            INetworkRepository networkRepository, 
            IScheduleRepository scheduleRepository, 
            IRatingRepository ratingRepository,
            IImageRepository imageRepository, 
            ILinkRepository linkRepository,
            IExternalRepository externalRepository, 
            ICountryRepository countryRepository, 
            IWebChannelRepository webChannelRepository,
            ISelfRepository selfRepository,
            IGenreRepository genreRepository,
            IEpisodeRepository episodeRepository)
        {
            _context = context;
            Shows = showRepository;
            Networks = networkRepository;
            Schedules = scheduleRepository;
            Ratings = ratingRepository;
            Images = imageRepository;
            Episodes = episodeRepository;
            Genres = genreRepository;
            Selfs = selfRepository;
            WebChannels = webChannelRepository;
            Countries = countryRepository;
            Externals = externalRepository;
            Links = linkRepository;
            Externals = externalRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
            return;
        }

        protected void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }
    }
}
