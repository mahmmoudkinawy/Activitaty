﻿namespace API.Controllers;

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

    [HttpGet("{id}", Name = "GetActivity")]
    public async Task<IActionResult> GetActivity([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetActivityProcess.Request
        {
            ActivityId = id
        }, cancellationToken);

        if (response is null) return NotFound();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddActivity(
        [FromBody] CreateActivityProcess.Request request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return CreatedAtRoute(nameof(GetActivity), new
        {
            response.Id
        }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditActivity(
        [FromRoute] Guid id,
        [FromBody] EditActivityProcess.Request request,
        CancellationToken cancellationToken)
    {
        request.Id = id;

        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteActivityProcess.Request
        {
            Id = id
        }, cancellationToken);

        return NoContent();
    }
}
