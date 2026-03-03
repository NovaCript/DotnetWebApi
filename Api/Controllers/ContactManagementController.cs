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

    [HttpDelete("contacts/{id}")]
    public void DeleteContact(int id)
    {
        Contact contact;
        for (int i = 0; i < contactStorage.Contacts.Count; i++)
        {
            if (contactStorage.Contacts[i].Id == id)
            {
                contact = contactStorage.Contacts[i];
                contactStorage.Contacts.Remove(contact);
                return;
            }
        }
    }

}