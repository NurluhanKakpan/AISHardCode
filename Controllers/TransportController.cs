using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using techTask2.Dto;
using techTask2.Interface;
using techTask2.Models;

namespace techTask2.Controllers;
[Route("api/transport")]
[ApiController]
public class TransportController : Controller
{
    private readonly ITransportRepository _transportRepository;
    private readonly IMapper _mapper;

    public TransportController(ITransportRepository transportRepository, IMapper mapper)
    {
        _transportRepository = transportRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Transport>))]
    public IActionResult GetTransports()
    {
        var ts = _transportRepository.GetTransports();
        var result = _mapper.Map<IEnumerable<TransportDto>>(ts);
        return Ok(result);
    }

    [HttpGet("{transportId}")]
    [ProducesResponseType(200, Type = typeof(Transport))]
    public IActionResult GetTransport(int transportId)
    {
        var ts = _transportRepository.GetTransport(transportId);
        if (ts == null)
        {
            return BadRequest();
        }
        var result = _mapper.Map<TransportDto>(ts);
        return Ok(result);
    }
}