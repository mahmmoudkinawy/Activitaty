namespace API.Processes.Activities;
public class DeleteActivityProcess
{
    public class Request : IRequest
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Request>
    {
        private readonly ActivitatyDbContext _context;

        public Handler(ActivitatyDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);

            //if (activity is null) return null;

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
