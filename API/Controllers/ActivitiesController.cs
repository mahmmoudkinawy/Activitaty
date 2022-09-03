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
    public async Task<IActionResult> GetActivities(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllActivitiesProcess.Request(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetActivityProcess.Request
        {
            ActivityId = id
        }, cancellationToken);

        if (response is null) return NotFound();

        return Ok(response);
    }
}
