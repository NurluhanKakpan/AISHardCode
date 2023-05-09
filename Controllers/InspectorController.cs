using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using techTask2.Dto;
using techTask2.Interface;
using techTask2.Models;
using techTask2.ServiceInterface;

namespace techTask2.Controllers;

[Route("api/inspectors")]
[ApiController]
public class InspectorController : Controller
{

    private readonly IInspectorService _inspectorService;

    public InspectorController(IInspectorService inspectorService)
    {
        _inspectorService = inspectorService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Inspector>))]
    public IActionResult GetInspectors()
    {
        var result = _inspectorService.GetInspectors();
        return Ok(result);
    }

    
    [HttpGet("{inspectorId}")]
    [ProducesResponseType(200, Type = typeof(Inspector))]
    public IActionResult GetInspector(int inspectorId)
    {
        var result = _inspectorService.GetInspector(inspectorId);
        return Ok(result);
    }

    
    [HttpPost]
    [ProducesResponseType(204)]
    public IActionResult CreateInspector([FromBody] InspectorCreateDto? inspectorDto)
    {
        if (!_inspectorService.CheckInspectorDto(inspectorDto))
        {
            return BadRequest();
        }
        const string iinPattern = @"^\d{12}$";
        if (!_inspectorService.CheckInspectorInputIin(iinPattern, inspectorDto))
        {
            return BadRequest();
        }
        if (!_inspectorService.CheckInspectorWithSameIin(inspectorDto))
        {
            return BadRequest();
        }
        if (!_inspectorService.CreateInspector(inspectorDto))
        {
            return BadRequest();
        }
        return Ok("Successfully Created");
    }
}