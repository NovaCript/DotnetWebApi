public interface IStorage
{
    public List<Contact> GetAll();
    public Contact GetById(int id);
    public int Add(ContactPresentationDto contact);
    public bool Remove(int id);
    public bool Update(int id, ContactPresentationDto contactDto);
}
