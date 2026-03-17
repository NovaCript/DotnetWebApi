using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{

    private readonly ContactService _contactService;

    public ContactManagementController(ContactService contactService)
    {
        this._contactService = contactService;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] ContactCreateDto contact)
    {
        var result = _contactService.CreateContact(contact);
        if (result != null)
        {
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }
        return Conflict("Контакт с указаным ID существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(_contactService.GetAllContact());
    }

    [HttpGet("contacts/{id}")]
    public IActionResult GetContactById(int id)
    {
        ContactReadDto contact = _contactService.GetContactById(id);
        if (contact == null)
        {
            return NotFound("Пользователя с таким ID не существует");
        }
        return Ok(contact);
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id)
    {
        bool result = _contactService.RemoveContact(id);
        if (result)
        {
            return Ok();
        }
        return BadRequest("Ошибка ID");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact(int id, [FromBody] ContactCreateDto contactDto)
    {
        bool result = _contactService.UpdateContact(id, contactDto);
        if (result)
        {
            return Ok(_contactService.GetContactById(id));
        }
        return NotFound("Контакт с указаным ID не существует");
    }

}