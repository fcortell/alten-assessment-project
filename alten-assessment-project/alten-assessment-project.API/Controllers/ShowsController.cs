using alten_assessment_project.Application.Shows;
using alten_assessment_project.Application.Shows.Queries;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace alten_assessment_project.API.Controllers
{
    [ApiController]
    [Route("Shows")]
    public class ShowsController : BaseController
    {
        /// <summary>
        /// Gets all shows available on DB
        /// </summary>
        /// <response code="200">The user</response>
        /// <response code="404">User not found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ShowDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [HttpGet]
        public async Task<IActionResult> GetAllShows(
           CancellationToken cancellationToken)
        {
            GetAllShowsQuery query = new GetAllShowsQuery();

            Result<List<ShowDTO>> result = await Mediator.Send(query, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return Problem();
        }
    }
}
