namespace API.DbContexts;
public class Seed
{
    public static async Task SeedActivities(ActivitatyDbContext context)
    {
        if (await context.Activities.AnyAsync()) return;

        var activityFaker = new Faker<ActivityEntity>()
            .RuleFor(a => a.Title, f => f.Hacker.Noun())
            .RuleFor(a => a.Description, f => f.Lorem.Text())
            .RuleFor(a => a.Date, f => f.Date.Between(DateTime.UtcNow, DateTime.UtcNow.AddDays(-15)))
            .RuleFor(a => a.Category, f => f.Commerce.Categories(1).FirstOrDefault())
            .RuleFor(a => a.City, f => f.Address.City())
            .RuleFor(a => a.Venue, f => f.Address.StreetAddress());

        foreach (var activity in activityFaker.Generate(15))
        {
            context.Activities.Add(activity);
            await context.SaveChangesAsync();
        }
    }
}
