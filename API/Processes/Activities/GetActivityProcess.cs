namespace API.Processes.Activities;
public class GetActivityProcess
{
    public class Request : IRequest<Response>
    {
        public Guid ActivityId { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ActivitatyDbContext _context;
        private readonly IMapper _mapper;

        public Handler(ActivitatyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response?> Handle(Request request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(new object?[] { request.ActivityId }, cancellationToken: cancellationToken);

            if (activity is null) return null;

            return _mapper.Map<Response>(activity);
        }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ActivityEntity, Response>();
        }
    }
}
