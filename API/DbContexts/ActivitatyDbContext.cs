namespace API.DbContexts;
public class ActivitatyDbContext : DbContext
{
    public ActivitatyDbContext(DbContextOptions<ActivitatyDbContext> options) : base(options)
    { }

    public DbSet<ActivityEntity> Activities { get; set; }
}
