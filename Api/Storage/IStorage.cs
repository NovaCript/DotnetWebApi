public interface IStorage
{
    public List<ContactReadDto> GetAll();
    public ContactReadDto GetById(int id);
    public int Add(ContactCreateDto contact);
    public bool Remove(int id);
    public bool Update(int id, ContactCreateDto contactDto);
}
