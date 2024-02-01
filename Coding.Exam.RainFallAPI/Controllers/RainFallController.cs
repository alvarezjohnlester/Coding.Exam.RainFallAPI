using Coding.Exam.RainFallAPI.Interface;
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
		public async Task<ActionResult> Get(int stationId, int count = 10)
		{
			try
			{
				var response =  await _iRainFallService.GetRainFallReading(stationId);

				return Ok();
			}
			catch (Exception)
			{

				throw;
			}
			
		}
	}
}
