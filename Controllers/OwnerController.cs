using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using techTask2.Dto;
using techTask2.Interface;
using techTask2.Models;
using techTask2.ServiceInterface;

namespace techTask2.Controllers;


[Route("api/owners")]
[ApiController]
public class OwnerController : Controller
{
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService)
    {
        _ownerService = ownerService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
    public IActionResult GetOwners()
    {
        var result = _ownerService.GetOwners();
        return Ok(result);
    }

    [HttpGet("{ownerId:int}")]
    [ProducesResponseType(200, Type = typeof(OwnerDto))]
    public IActionResult GetOwner(int ownerId)
    {
        var result = _ownerService.GetOwner(ownerId);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    public IActionResult CreateOwner([FromBody] OwnerCreateDto? ownerDto)
    {
        if (!_ownerService.CheckOwnerDto(ownerDto))
        {
            return BadRequest();
        }
        if (!_ownerService.CheckOwnerExistsWithSameIin(ownerDto))
        {
            return BadRequest();
        }
        const string iinPattern = @"^\d{12}$";
        if (!_ownerService.CheckOwnerInputIin(iinPattern, ownerDto))
        {
            return BadRequest();
        }
        if (!_ownerService.CreateOwner(ownerDto))
        {
            return StatusCode(500);
        }
        return Ok("Successfully created");
    }
}