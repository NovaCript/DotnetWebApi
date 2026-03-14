using System.Text;
using Microsoft.Data.Sqlite;

public class SqliteStorage : IStorage
{
    private readonly string connectionString;

    public SqliteStorage(string connectionString)
    {
        this.connectionString = connectionString;
    }

    string commandAddContact = "insert into contacts (name, email) values (@name, @email)";
    string commandGetAllContact = "SELECT * FROM contacts";
    string commandRemove = "delete from contacts where id = @id";
    string commandUpdateContact = "update contacts set name = @name, email = @email where id = @id";
    string commandGetByIdContact = "select * from contacts where id = @id";

    public bool Add(Contact contact)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = commandAddContact;
        command.Parameters.AddWithValue("@name", contact.Name);
        command.Parameters.AddWithValue("@email", contact.Email);
        try
        {
            return command.ExecuteNonQuery() > 0;
        }
        catch (SqliteException)
        {

            return false;
        }
    }

    public List<Contact> GetAll()
    {
        var contact = new List<Contact>();

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = commandGetAllContact;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            contact.Add(new Contact()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }
        // reader.Close();
        // connection.Close();
        return contact;
    }

    public Contact GetById(int id)
    {
        Contact contact = new Contact();


        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = commandGetByIdContact;

        command.Parameters.AddWithValue("@id", id);
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            contact.Id = reader.GetInt32(0);
            contact.Name = reader.GetString(1);
            contact.Email = reader.GetString(2);
        }

        return contact;
    }

    public bool Remove(int id)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = commandRemove;

        command.Parameters.AddWithValue("@id", id);
        return command.ExecuteNonQuery() > 0;
    }

    public bool Update(int id, ContactDto contactDto)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = commandUpdateContact;
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@name", contactDto.Name);
        command.Parameters.AddWithValue("@email", contactDto.Email);

        return command.ExecuteNonQuery() > 0;
    }
}