public class ContactService
{
    private readonly IStorage _storage;

    public ContactService(IStorage storage)
    {
        this._storage = storage;
    }

    public ContactReadDto CreateContact(ContactCreateDto dto)
    {
        int newId = _storage.Add(dto);

        if (newId == 0) return null;

        return new ContactReadDto
        {
            Id = newId,
            Name = dto.Name,
            Email = dto.Email
        };
    }

    public List<ContactReadDto> GetAllContact()
    {
        return _storage.GetAll();
    }

    public ContactReadDto GetContactById(int id)
    {
        return _storage.GetById(id);
    }

    public bool RemoveContact(int id)
    {
        return _storage.Remove(id);
    }

    public bool UpdateContact(int id, ContactCreateDto contactDto)
    {
        return _storage.Update(id, contactDto);
    }

}