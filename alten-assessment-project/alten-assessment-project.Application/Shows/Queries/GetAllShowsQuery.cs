using alten_assessment_project.Domain.Entities;
using alten_assessment_project.Domain.Repositories;
using FluentResults;
using MediatR;

namespace alten_assessment_project.Application.Shows.Queries
{
    public record GetAllShowsQuery : IRequest<Result<List<ShowDTO>>>
    {
    }

    public class GetAllShowsQueryHandler : IRequestHandler<GetAllShowsQuery, Result<List<ShowDTO>>>
    {
        private readonly IShowRepository _showRepository;
        private readonly INetworkRepository _networkRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IWebChannelRepository _webChannelRepository;
        private readonly IExternalRepository _externalRepository;
        private readonly IGenreRepository _genreRepository;

        public GetAllShowsQueryHandler(IShowRepository showRepository, 
            INetworkRepository networkRepository,
            ICountryRepository countryRepository,
            IWebChannelRepository webChannelRepository,
            IExternalRepository externalRepository,
            IGenreRepository genreRepository)
        {
            _showRepository = showRepository;
            _networkRepository = networkRepository;
            _countryRepository = countryRepository;
            _webChannelRepository = webChannelRepository;
            _externalRepository = externalRepository;
            _genreRepository = genreRepository;
        }

        public async Task<Result<List<ShowDTO>>> Handle(GetAllShowsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Show?> shows = await _showRepository.GetAllAsync();

            // Convert the list of Show entities to ShowDTOs
            List<ShowDTO> showDTOs = new List<ShowDTO>();
            foreach (Show? show in shows)
            {
                if (show != null)
                {
                    // Convert network to NetworkDTO
                    NetworkDTO networkDTO = null;
                    Network network = await _networkRepository.GetByIdAsync(show.NetworkId.GetValueOrDefault());
                    if (network != null)
                    {
                        Country country = await _countryRepository.GetByIdAsync(network.CountryId.GetValueOrDefault());
                        // Convert country to CountryDTO
                        CountryDTO countryDTO = new CountryDTO
                        {
                            Name = country.Name,
                            Code = country.Code
                        };
                        // Convert network to NetworkDTO
                        networkDTO = new NetworkDTO
                        {
                            Id = network.Id,
                            Name = network.Name,
                            Country = countryDTO
                        };
                    }
                    

                    // Convert WebChannel to WebChannelDTO
                    WebChannel? webChannel = await _webChannelRepository.GetByIdAsync(show.WebChannelId.GetValueOrDefault());
                    WebChannelDTO? webChannelDTO = null;
                    if (webChannel != null)
                    {
                        Country webChannelCountry = await _countryRepository.GetByIdAsync(webChannel.CountryId.GetValueOrDefault());
                        CountryDTO webChannelCountryDTO = null;
                        if(webChannelCountry != null)
                        {
                            // Convert country to CountryDTO
                            webChannelCountryDTO = new CountryDTO
                            {
                                Name = webChannelCountry.Name,
                                Code = webChannelCountry.Code
                            };
                            webChannelDTO = new WebChannelDTO
                            {
                                Id = webChannel.Id,
                                Name = webChannel.Name,
                                Country = webChannelCountryDTO
                            };
                        }
                        
                    }
                   

                    IEnumerable<Genre> genres = await _genreRepository.GetAllByIdAsync(show.Id);

                    showDTOs.Add(new ShowDTO
                    {
                        Id = show.Id,
                        Name = show.Name,
                        Type = show.Type,
                        Language = show.Language,
                        Genres = genres.Select(x => x.Name).ToList(),
                        Status = show.Status,
                        Runtime = show.Runtime,
                        AverageRuntime = show.AverageRuntime,
                        Premiered = show.Premiered,
                        Ended = show.Ended,
                        OfficialSite = show.OfficialSite,
                        Schedule = new ScheduleDTO
                        {
                            Time = show.Schedule.Time,
                            Days = show.Schedule.Days
                        },
                        Rating = new RatingDTO
                        {
                            Average = show.Rating.Average
                        },
                        Weight = show.Weight,
                        Network = networkDTO,
                        WebChannel = webChannelDTO,
                        External = new ExternalDTO
                        {
                            Tvrage = show.External.Tvrage,
                            Thetvdb = show.External.Thetvdb,
                            Imdb = show.External.Imdb
                        }

                    });
                }
            }

            return showDTOs;
        }
    }
}