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
        contactStorage.Contacts.Add(contact);
    }

    [HttpGet("contacts")]
    public List<Contact> GetContacts()
    {
        return contactStorage.Contacts;
    }

}