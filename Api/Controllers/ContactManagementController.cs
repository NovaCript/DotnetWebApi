using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{

    private readonly ContactService contactService;

    public ContactManagementController(ContactService contactService)
    {
        this.contactService = contactService;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] ContactCreateDto contact)
    {
        var result = contactService.CreateContact(contact);
        if (result != null)
        {
            return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
        }
        return Conflict("Контакт с указаным ID существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(contactService.GetAllContact());
    }

    [HttpGet("contacts/{id}")]
    public IActionResult GetContactById(int id)
    {
        ContactReadDto contact = contactService.GetContactById(id);
        if (contact == null)
        {
            return NotFound("Пользователя с таким ID не существует");
        }
        return Ok(contact);
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id)
    {
        bool result = contactService.RemoveContact(id);
        if (result)
        {
            return Ok();
        }
        return BadRequest("Ошибка ID");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact(int id, [FromBody] ContactCreateDto contactDto)
    {
        bool result = contactService.UpdateContact(id, contactDto);
        if (result)
        {
            return Ok(contactService.GetContactById(id));
        }
        return NotFound("Контакт с указаным ID не существует");
    }

}