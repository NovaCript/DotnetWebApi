using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{
    private readonly IStorage storage;

    public ContactManagementController(IStorage storage)
    {
        this.storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        bool result = storage.Add(contact);
        if (result)
        {
            return CreatedAtAction(nameof(GetContactById), new { id = contact.Id }, contact);
        }
        return Conflict("Контакт с указаным ID существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(storage.GetAll());
    }

    [HttpGet("contacts/{id}")]
    public IActionResult GetContactById(int id)
    {
        Contact contact = storage.GetById(id);
        if (contact == null)
        {
            return NotFound("Пользователя с таким ID не существует");
        }
        return Ok(contact);
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id)
    {
        bool result = storage.Remove(id);
        if (result)
        {
            return Ok();
        }
        return BadRequest("Ошибка ID");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact(int id, [FromBody] ContactDto contactDto)
    {
        bool result = storage.Update(id, contactDto);
        if (result)
        {
            return Ok(storage.GetById(id));
        }
        return NotFound("Контакт с указаным ID не существует");
    }

}