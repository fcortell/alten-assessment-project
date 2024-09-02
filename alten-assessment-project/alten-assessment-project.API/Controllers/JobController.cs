using alten_assessment_project.Application.Job;
using Microsoft.AspNetCore.Mvc;

namespace alten_assessment_project.API.Controllers
{
    [ApiController]
    [Route("Job")]
    public class JobController : BaseController
    {
        /// <summary>
        /// Executes job that calls external API to get shows and save them to DB
        /// </summary>
        /// <response code="200">ID of the created user</response>
        /// <response code="400">Validation error</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<bool>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [HttpGet]
        public async Task<IActionResult> ExecuteJob()
        {
            GetExternalShowsCommand getExternalShowsCommand = new GetExternalShowsCommand();
            var externalShowsList = await Mediator.Send(getExternalShowsCommand);
            SaveExternalShowsCommand saveExternalShowsCommand = new SaveExternalShowsCommand();
            saveExternalShowsCommand.externalShows = externalShowsList.Value;
            var result = await Mediator.Send(saveExternalShowsCommand);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return Problem();
        }
    }
}
