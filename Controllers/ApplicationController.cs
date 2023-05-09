using Microsoft.AspNetCore.Mvc;
using techTask2.Data;
using techTask2.Dto;
using techTask2.Models;
using techTask2.ServiceInterface;

namespace techTask2.Controllers;

[Route("api/application")]
[ApiController]
public partial class ApplicationController : Controller
{
    private readonly IApplicationService _applicationService;
    private readonly IMessageService _messageService;

    public ApplicationController(IApplicationService applicationService,IMessageService messageService)
    {
        _applicationService = applicationService;
        _messageService = messageService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Application>))]
    public IActionResult GetApplication()
    {
        var result = _applicationService.GetApplications();
        return Ok(result);
    }


    [HttpGet("{inspectorId}")]
    [ProducesResponseType(200, Type = typeof(Application))]
    public IActionResult GetApplication(int inspectorId)
    {
        var result = _applicationService.GetApplication(inspectorId);
        return Ok(result);

    }
    

    [HttpPost]
    [ProducesResponseType(204)]
    public IActionResult CreateApplication([FromQuery] int ownerId,
        [FromBody] ApplicationCreateDto? applicationDto)
        {
        if (!_applicationService.CheckApplication(applicationDto))
        {
            return BadRequest();
        }
        if (!_applicationService.CheckOwner(ownerId, applicationDto))
        {
            return BadRequest();
        }
        if (!_applicationService.CheckTransportInformation(applicationDto))
        {
            return BadRequest();
        }
        if (!_applicationService.CheckApplicationType(applicationDto))
        {
            return BadRequest();
        }
        if (!_applicationService.CheckApplicationFromDb(applicationDto))
        {
            return StatusCode(422);
        }
        if (!_applicationService.CheckApplicationTypeWithSrts(applicationDto))
        {
            return StatusCode(403);
        }
        if (!_applicationService.CheckTransportFromDb(ownerId,applicationDto))
        {
            return StatusCode(402);
        }
        if (!_applicationService.CreateApplicationAndTransport(ownerId, applicationDto))
        {
            return StatusCode(500);
        }
        return Ok("Successfully");
    }

    [HttpPost("{inspectorId:int}/cancel")]
    [ProducesResponseType(204)]
    public IActionResult CancelApplication(int inspectorId, [FromQuery] int applicationId ,[FromBody] MessageCreateDto? messageDto )
    {
        if (!_messageService.CreateMessage(applicationId, messageDto!))
        {
            return StatusCode(500);
        }
        if (_applicationService.CancelApplication(inspectorId,applicationId))
        {
            return Ok("Successfully canceled");
        }
        

        return StatusCode(500);
    }
    
}