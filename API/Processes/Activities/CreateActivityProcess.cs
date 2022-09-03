namespace API.Processes.Activities;
public class CreateActivityProcess
{
    public class Request : IRequest<Response>
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
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
            var activityToCreate = _mapper.Map<ActivityEntity>(request);

            _context.Activities.Add(activityToCreate);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<Response>(activityToCreate);
        }

    }

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(a => a.Title)
                .MinimumLength(3)
                .MaximumLength(255)
                .NotEmpty();

            RuleFor(a => a.Date)
                .NotEmpty();

            RuleFor(a => a.Description)
                .MinimumLength(30)
                .MaximumLength(3000)
                .NotEmpty();

            RuleFor(a => a.Category)
                .MinimumLength(3)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(a => a.City)
                .MinimumLength(2)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(a => a.Venue)
                .MinimumLength(3)
                .MaximumLength(255)
                .NotEmpty();
        }
    }

    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ActivityEntity, Response>();
            CreateMap<Request, ActivityEntity>();
        }
    }

}
