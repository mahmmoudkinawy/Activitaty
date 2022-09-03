namespace API.Processes.Activities;
public class EditActivityProcess
{
    public class Request : IRequest
    {
        public ActivityEntity Activity { get; set; }
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
            var acitivtyFromDb = await _context.Activities.FindAsync(new object?[] { request.Activity.Id }, cancellationToken: cancellationToken);

            //if (acitivtyFromDb is null) return null;

            _mapper.Map(request.Activity, acitivtyFromDb);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        public class Mapper : Profile
        {
            public Mapper()
            {
                CreateMap<ActivityEntity, ActivityEntity>();
            }
        }
    }
}
