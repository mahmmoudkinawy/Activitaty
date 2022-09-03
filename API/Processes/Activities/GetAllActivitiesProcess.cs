namespace API.Processes.Activities;
public class GetAllActivitiesProcess
{
    public class Request : IRequest<IReadOnlyList<ActivityEntity>> { }

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

    public class Handler : IRequestHandler<Request, IReadOnlyList<ActivityEntity>>
    {
        private readonly ActivitatyDbContext _context;
        private readonly IMapper _mapper;

        public Handler(ActivitatyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ActivityEntity>> Handle(Request request, CancellationToken cancellationToken)
        {
            var activities = await _context.Activities.ToListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<IReadOnlyList<ActivityEntity>>(activities);
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
