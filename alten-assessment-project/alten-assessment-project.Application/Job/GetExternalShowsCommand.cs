using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alten_assessment_project.Application.Shows;
using alten_assessment_project.Domain.Repositories;
using FluentResults;
using MediatR;
using tvmazeAPIClient;
using tvmazeAPIClient.Model;

namespace alten_assessment_project.Application.Job
{
    public record GetExternalShowsCommand : IRequest<Result<List<TVMazeShow>>>
    {

    }

    public class GetExternalShowsCommandHandler : IRequestHandler<GetExternalShowsCommand, Result<List<TVMazeShow>>>
    {
        private readonly IMediator? _mediator;
        private readonly IShowRepository _userRepository;

        public GetExternalShowsCommandHandler(IShowRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        public GetExternalShowsCommandHandler(IShowRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<TVMazeShow>>> Handle(GetExternalShowsCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Get external shows
                List<TVMazeShow> externalShows = new List<TVMazeShow>();
                TVMazeAPIClient client = new TVMazeAPIClient();
                externalShows = await client.GetShows();
                return Result.Ok(externalShows);
            }
            catch (Exception ex)
            {
                Error error = new Error(ex.Message);
                return Result.Fail<List<TVMazeShow>>(error);
            }
        }
    }
}
