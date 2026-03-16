public class ContactService
{
    private readonly IStorage _storage;

    public ContactService(IStorage storage)
    {
        _storage = storage;
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
}