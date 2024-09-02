using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Domain.Repositories;

namespace alten_assessment_project.Domain
{
    public interface IUnitOfWork
    {
        IDatabaseTransaction BeginTransaction();
        void Save();

        IShowRepository Shows { get; }
        ICountryRepository Countries { get; }
        IEpisodeRepository Episodes { get; }
        IExternalRepository Externals { get; }
        IGenreRepository Genres { get; }
        IImageRepository Images { get; }
        ILinkRepository Links { get; }
        IRatingRepository Ratings { get; }
        INetworkRepository Networks { get; }
        IScheduleRepository Schedules { get; }
        ISelfRepository Selfs { get; }
        IWebChannelRepository WebChannels { get; }

    }
}
