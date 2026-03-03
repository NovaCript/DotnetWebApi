using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{
    private readonly ContactStorage contactStorage;

    public ContactManagementController(ContactStorage contactStorage)
    {
        this.contactStorage = contactStorage;
    }

    [HttpPost("contacts")]
    public void Create([FromBody] Contact contact)
    {
        contactStorage.Add(contact);
    }

    [HttpGet("contacts")]
    public List<Contact> GetContacts()
    {
        return contactStorage.GetAll();
    }

    [HttpDelete("contacts/{id}")]
    public void DeleteContact(int id)
    {
        contactStorage.Remove(id);
    }

    [HttpPut("contacts/{id}")]
    public void UpdateContact(int id, [FromBody] ContactDto contactDto)
    {
        contactStorage.Update(id, contactDto);
    }

}