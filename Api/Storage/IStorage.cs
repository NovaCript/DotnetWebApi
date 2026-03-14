public interface IStorage
{
    public List<Contact> GetAll();
    public Contact GetById(int id);
    public bool Add(Contact contact);
    public bool Remove(int id);
    public bool Update(int id, ContactDto contactDto);
}
