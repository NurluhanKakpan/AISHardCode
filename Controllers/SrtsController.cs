using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using techTask2.Dto;
using techTask2.Interface;
using techTask2.Models;
using techTask2.ServiceInterface;

namespace techTask2.Controllers;

[Route("api/srts")]
[ApiController]
public class SrtsController : Controller
{
      
        private readonly ISrtsService _srtsService;

        public SrtsController(ISrtsService srtsService)
        {
                _srtsService = srtsService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Srts>))]
        public IActionResult GetSrts()
        {
                var result = _srtsService.GetSrtses();
                return Ok(result);
        }

        [HttpGet("{srtsId:int}")]
        [ProducesResponseType(200, Type = typeof(Srts))]
        public IActionResult GetSrts(int srtsId)
        {
                var result = _srtsService.GetSrts(srtsId);
                return Ok(result);
        }

        [HttpPost("{inspectorId:int}/apps/{appId:int}")]
        [ProducesResponseType(204)]
        public IActionResult CreateSrts(int inspectorId, int appId)
        {
                if (!_srtsService.CheckInspectorAndApplication(inspectorId, appId))
                {
                        return BadRequest();
                }

                if (!_srtsService.CreateSrts(inspectorId, appId))
                {
                        return BadRequest();
                }

                return Ok("Successfully created");

        }
        
        
        
        
        
}