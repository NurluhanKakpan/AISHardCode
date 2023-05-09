using Microsoft.AspNetCore.Mvc;
using techTask2.Dto;
using techTask2.ServiceInterface;

namespace techTask2.Controllers;


[Route("api/message/{ownerId:int}")]
public class MessageController :Controller
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<MessageDto>))]
    public IActionResult GetMessages(int ownerId)
    {
        var result = _messageService.GetMessages(ownerId);
        return Ok(result);
    }
}