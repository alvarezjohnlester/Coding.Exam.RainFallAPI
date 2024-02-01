using Coding.Exam.RainFallAPI.Interface;
using Coding.Exam.RainFallAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Coding.Exam.RainFallAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RainFallController : ControllerBase
	{
		private readonly ILogger<RainFallController> _logger;
		private readonly IRainFallService _iRainFallService;

		public RainFallController(ILogger<RainFallController> logger, IRainFallService rainFallService)
        {
			_logger = logger;
			_iRainFallService = rainFallService;
		}

		
		[HttpGet("id/{stationId:range(1,100)}/readings")]
		[ProducesResponseType(typeof(RainFallReadingResponse),StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status404NotFound)]
		[ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(ErrorResponse),StatusCodes.Status500InternalServerError)]
		[Consumes("application/json")]
		[Produces("application/json")]
		public async Task<IActionResult> Get(int stationId, int count = 10)
		{
			try
			{
				if (stationId == 0 || stationId == null) { return BadRequest(new ErrorResponse { errorCode = 400, message= "invalid parameter"}); }
				RainFallReadingResponse response =  await _iRainFallService.GetRainFallReading(stationId, count);
				if (response.items.Count == 0)
				{
					return NotFound(new ErrorResponse { errorCode = 404, message = "not found" });
				}
				return Ok(response);
			}
			catch (Exception ex )
			{
				return StatusCode(500, new ErrorResponse { errorCode = 404, message = "internal server error" }); 
			}
			
		}
	}
}
