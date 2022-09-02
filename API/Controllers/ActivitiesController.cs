namespace API.Controllers;

[Route("api/activities")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly ActivitatyDbContext _context;

    public ActivitiesController(ActivitatyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ActivityEntity>>> GetActivities()
    {
        return Ok(await _context.Activities.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityEntity>> GetActivity([FromRoute] Guid id)
    {
        var activity = await _context.Activities.FindAsync(id);

        if (activity is null) return NotFound();

        return Ok(activity);
    }
}
