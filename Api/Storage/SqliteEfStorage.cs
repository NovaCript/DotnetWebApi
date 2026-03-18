public class SqliteEfStorage : IStorage
{

    private readonly SqliteDbContext _context;

    public SqliteEfStorage(SqliteDbContext context)
    {
        this._context = context;
    }

    public Contact Add(Contact contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return contact;
    }

    public List<Contact> GetAll()
    {
        return _context.Contacts.ToList();
    }

    public Contact GetById(int id)
    {
        return _context.Contacts.Find(id);
    }

    public bool Remove(int id)
    {
        var contact = _context.Contacts.Find(id);
        if (contact == null) return false;
        _context.Contacts.Remove(contact);
        _context.SaveChanges();
        return true;
    }

    public bool Update(int id, Contact contactUpdate)
    {
        var contact = _context.Contacts.Find(id);
        if (contact == null) return false;
        contact.Name = contactUpdate.Name;
        contact.Email = contactUpdate.Email;
        _context.SaveChanges();
        return true;

    }
}