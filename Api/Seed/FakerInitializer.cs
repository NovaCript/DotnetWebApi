using Bogus;
using Microsoft.Data.Sqlite;

public class FakerInitializer : IInitializer
{
    private string connectionString;
    public FakerInitializer(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Initialize()
    {

        string commandAddContact = @"
            insert into contacts (name, email)
            values (@name, @email);
            ";
        string commandCreateTable = @"
            create table if not exists Contacts (
                id integer primary key autoincrement,
                name text not null,
                email text not null
            );
        ";
        string commandCountContact = @"
            select count(*)
            from Contacts
            ";

        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        command.CommandText = commandCreateTable;
        command.ExecuteNonQuery();

        command.CommandText = commandCountContact;

        long count = (long)command.ExecuteScalar();
        if (count == 0)
        {
            var faker = new Faker<Contact>("ru")
            .RuleFor(c => c.Name, f => f.Person.FullName)
            .RuleFor(c => c.Email, f => f.Internet.Email());

            var contacts = faker.Generate(20);

            foreach (var contact in contacts)
            {
                command.CommandText = commandAddContact;
                command.Parameters.Clear();

                command.Parameters.AddWithValue("@name", contact.Name);
                command.Parameters.AddWithValue("@email", contact.Email);

                command.ExecuteNonQuery();
            }
        }



    }
}