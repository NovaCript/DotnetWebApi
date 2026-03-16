public class ContactService
{
    private readonly IStorage _storage;

    public ContactService(IStorage storage)
    {
        _storage = storage;
    }

    public ContactPersistentDto CreateContact(ContactPresentationDto dto)
    {
        int newId = _storage.Add(dto);

        if (newId == 0) return null;

        return new ContactPersistentDto
        {
            Id = newId,
            Name = dto.Name,
            Email = dto.Email
        };
    }
}