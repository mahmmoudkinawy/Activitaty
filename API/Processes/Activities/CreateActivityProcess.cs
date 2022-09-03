namespace API.Processes.Activities;
public class CreateActivityProcess
{
    public class Request : IRequest<Response>
    {
        public ActivityEntity Activity { get; set; }
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

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            _context.Activities.Add(request.Activity);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Response>(request.Activity);
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
