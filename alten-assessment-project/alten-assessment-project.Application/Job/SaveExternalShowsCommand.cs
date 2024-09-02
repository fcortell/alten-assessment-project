using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentResults;
using alten_assessment_project.Domain.Entities;
using alten_assessment_project.Domain.Repositories;
using alten_assessment_project.Application.Shows;
using tvmazeAPIClient.Model;
using System.Diagnostics.Metrics;
using alten_assessment_project.Domain;

namespace alten_assessment_project.Application.Job
{
    public record SaveExternalShowsCommand : IRequest<Result<bool>>
    {
        public List<TVMazeShow> externalShows { get; set; }
    }

    public class SaveExternalShowsCommandHandler : IRequestHandler<SaveExternalShowsCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public SaveExternalShowsCommandHandler(IUnitOfWork unitOfWork,IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public SaveExternalShowsCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(SaveExternalShowsCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    // TODO: Add validation
                    // TODO: Create method to convert TVMazeShow to Show to improve testing
                    // Convert ExternalShowDTO to Show
                    foreach (TVMazeShow externalShow in request.externalShows)
                    {
                        Show show = new Show
                        {
                            Name = externalShow.Name,
                            Language = externalShow.Language,
                            Runtime = externalShow.Runtime,
                            Summary = externalShow.Summary,
                            Premiered = externalShow.Premiered,
                            Ended = externalShow.Ended,
                            OfficialSite = externalShow.OfficialSite,
                            Status = externalShow.Status,
                            AverageRuntime = externalShow.AverageRuntime,
                            Weight = externalShow.Weight,
                            Updated = externalShow.Updated,
                            ExternalId = externalShow.Id,
                            Url = externalShow.Url,
                            Type = externalShow.Type,
                        };


                        // Save related entities
                        if (externalShow.Schedule != null)
                        {
                            Domain.Entities.Schedule schedule = new Domain.Entities.Schedule
                            {
                                Time = externalShow.Schedule.Time,
                                Days = externalShow.Schedule.Days?.ToString(),
                            };
                            show.ScheduleId = _unitOfWork.Schedules.InsertAndGetId(schedule);
                        }

                        if (externalShow.Rating != null)
                        {
                            Domain.Entities.Rating rating = new Domain.Entities.Rating
                            {
                                Average = externalShow.Rating.Average,
                            };
                            show.RatingId = _unitOfWork.Ratings.InsertAndGetId(rating);
                        }

                        if (externalShow.WebChannel != null)
                        {
                            long? countryId = null;
                            if (externalShow.WebChannel.Country != null)
                            {
                                Domain.Entities.Country country = new Domain.Entities.Country
                                {
                                    Name = externalShow.WebChannel.Country?.Name,
                                    Code = externalShow.WebChannel.Country?.Code,
                                    Timezone = externalShow.WebChannel.Country?.Timezone,
                                };

                                countryId = _unitOfWork.Countries.InsertAndGetId(country);
                            }

                            Domain.Entities.WebChannel webChannel = new Domain.Entities.WebChannel
                            {
                                Name = externalShow.WebChannel.Name,
                                CountryId = countryId,
                                OfficialSite = externalShow.WebChannel.OfficialSite,
                            };

                            show.WebChannelId = _unitOfWork.WebChannels.InsertAndGetId(webChannel);

                        }

                        if (externalShow.Network != null)
                        {

                            long? countryId = null;
                            if (externalShow.Network.Country != null)
                            {
                                Domain.Entities.Country country = new Domain.Entities.Country
                                {
                                    Name = externalShow.Network.Country?.Name,
                                    Code = externalShow.Network.Country?.Code,
                                    Timezone = externalShow.Network.Country?.Timezone,
                                };

                                countryId = _unitOfWork.Countries.InsertAndGetId(country);
                            }

                            Domain.Entities.Network network = new Domain.Entities.Network
                            {
                                Name = externalShow.Network.Name,
                                CountryId = countryId,
                                OfficialSite = externalShow.Network.OfficialSite,
                            };

                            show.NetworkId = _unitOfWork.Networks.InsertAndGetId(network);
                        }

                        if (externalShow.Image != null)
                        {
                            Domain.Entities.Image image = new Domain.Entities.Image
                            {
                                Medium = externalShow.Image.Medium,
                                Original = externalShow.Image.Original,
                            };

                            show.ImageId = _unitOfWork.Images.InsertAndGetId(image);
                        }

                        if (externalShow.Externals != null)
                        {
                            Domain.Entities.External external = new Domain.Entities.External
                            {
                                Tvrage = externalShow.Externals.Tvrage,
                                Thetvdb = externalShow.Externals.Thetvdb,
                                Imdb = externalShow.Externals.Imdb,
                            };

                            show.ExternalId = _unitOfWork.Externals.InsertAndGetId(external);
                        }

                        if (externalShow.Links != null)
                        {
                            long? selfId = null;
                            if (externalShow.Links.Self != null)
                            {
                                Domain.Entities.Self self = new Domain.Entities.Self
                                {
                                    Href = externalShow.Links.Self.Href,
                                };

                                selfId = _unitOfWork.Selfs.InsertAndGetId(self);
                            }


                            long? nextEpisodeId = null;
                            if (externalShow.Links.Nextepisode != null)
                            {
                                Domain.Entities.Episode nextEpisode = new Domain.Entities.Episode
                                {
                                    Name = externalShow.Links.Nextepisode?.Name,
                                    Href = externalShow.Links.Nextepisode?.Href,
                                };

                                nextEpisodeId = _unitOfWork.Episodes.InsertAndGetId(nextEpisode);
                            }

                            long? previousEpisodeId = null;
                            if (externalShow.Links.Previousepisode != null)
                            {
                                Domain.Entities.Episode previousEpisodde = new Domain.Entities.Episode
                                {
                                    Name = externalShow.Links.Previousepisode?.Name,
                                    Href = externalShow.Links.Previousepisode?.Href,
                                };

                                previousEpisodeId = _unitOfWork.Episodes.InsertAndGetId(previousEpisodde);
                            }

                            Domain.Entities.Link link = new Domain.Entities.Link
                            {
                                SelfId = selfId,
                                PreviousEpisodeId = previousEpisodeId,
                                NextEpisodeId = nextEpisodeId,
                            };

                            show.LinkId = _unitOfWork.Links.InsertAndGetId(link);
                        }

                        _unitOfWork.Shows.Insert(show);

                    }

                    transaction.Commit();
                    return Result.Ok(true);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Error error = new Error(ex.Message);
                    return Result.Fail<bool>(error);
                }
            }
        }
    }
}
