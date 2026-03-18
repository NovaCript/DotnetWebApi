public interface IStorage
{
    public List<Contact> GetAll();
    public Contact GetById(int id);
    public Contact Add(Contact contact);
    public bool Remove(int id);
    public bool Update(int id, Contact contact);
}
