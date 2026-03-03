using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{
    private readonly ContactStorage contactStorage;

    public ContactManagementController(ContactStorage contactStorage)
    {
        this.contactStorage = contactStorage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        bool result = contactStorage.Add(contact);
        if (result)
        {
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }
        return Conflict("Контакт с указаным ID существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(contactStorage.GetAll());
    }

    [HttpGet("contacts/{id}")]
    public IActionResult GetContactById(int id)
    {
        Contact contact = contactStorage.GetById(id);
        if (contact == null)
        {
            return NotFound("Пользователя с таким ID не существует");
        }
        return Ok(contact);
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id)
    {
        bool result = contactStorage.Remove(id);
        if (result)
        {
            return NoContent();
        }
        return BadRequest("Ошибка ID");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact(int id, [FromBody] ContactDto contactDto)
    {
        bool result = contactStorage.Update(id, contactDto);
        if (result)
        {
            return Ok(contactStorage.GetById(id));
        }
        return NotFound("Контакт с указаным ID не существует");
    }

}