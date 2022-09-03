namespace API.Processes.Activities;
public class EditActivityProcess
{
    public class Request : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }

    public class Handler : IRequestHandler<Request>
    {
        private readonly ActivitatyDbContext _context;
        private readonly IMapper _mapper;

        public Handler(ActivitatyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            var acitivtyFromDb = await _context.Activities.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);

            //if (acitivtyFromDb is null) return null;

            _mapper.Map(request, acitivtyFromDb);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
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
            CreateMap<Request, ActivityEntity>();
        }
    }
}
