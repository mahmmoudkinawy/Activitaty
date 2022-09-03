namespace API.Controllers;

[Route("api/activities")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ActivitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ActivityEntity>>> GetActivities(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllActivitiesProcess.Request(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityEntity>> GetActivity([FromRoute] Guid id)
    {
        return Ok();
    }
}
