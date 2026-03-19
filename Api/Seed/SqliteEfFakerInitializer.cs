using Bogus;
using Microsoft.EntityFrameworkCore;

public class SqliteEfFakerInitializer : IInitializer
{
    private readonly SqliteDbContext _context;

    public SqliteEfFakerInitializer(SqliteDbContext context)
    {
        this._context = context;
    }
    public void Initialize()
    {
        _context.Database.Migrate();
        if (!_context.Contacts.Any())
        {
            var faker = new Faker<Contact>()
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Person.Email);
            var contacts = faker.Generate(20);

            _context.Contacts.AddRange(contacts);
            _context.SaveChanges();
        }
    }
}