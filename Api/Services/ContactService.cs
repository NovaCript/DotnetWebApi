public class ContactService
{
    private readonly IPaginationStorage _storage;

    public ContactService(IPaginationStorage storage)
    {
        this._storage = storage;
    }

    public ContactReadDto CreateContact(ContactCreateDto dto)
    {
        var contact = new Contact
        {
            Name = dto.Name,
            Email = dto.Email
        };

        var result = _storage.Add(contact);

        if (result == null) return null;

        return new ContactReadDto
        {
            Id = result.Id,
            Name = result.Name,
            Email = result.Email
        };
    }

    public List<ContactReadDto> GetAllContact()
    {
        var contacts = _storage.GetAll();

        return contacts.Select(c => new ContactReadDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email
        }).ToList();
    }

    public ContactReadDto GetContactById(int id)
    {
        var contact = _storage.GetById(id);
        if (contact == null) return null;

        return new ContactReadDto
        {
            Id = contact.Id,
            Name = contact.Name,
            Email = contact.Email
        };
    }

    public bool RemoveContact(int id)
    {

        return _storage.Remove(id);
    }

    public bool UpdateContact(int id, ContactCreateDto contactDto)
    {

        var contact = new Contact
        {
            Id = id,
            Name = contactDto.Name,
            Email = contactDto.Email
        };

        return _storage.Update(id, contact);
    }

    public PagedResponse GetContactsPaged(int pageNumber, int pageSize)
    {
        var (contacts, total) = _storage.GetContactsPaged(pageNumber, pageSize);

        return new
        PagedResponse(
            contacts, total, pageNumber, pageSize
        );
    }

}