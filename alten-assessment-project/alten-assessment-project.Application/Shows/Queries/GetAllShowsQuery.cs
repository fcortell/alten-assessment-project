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

        public GetAllShowsQueryHandler(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        public async Task<Result<List<ShowDTO>>> Handle(GetAllShowsQuery request, CancellationToken cancellationToken)
        {

            return null;
        }
    }
}