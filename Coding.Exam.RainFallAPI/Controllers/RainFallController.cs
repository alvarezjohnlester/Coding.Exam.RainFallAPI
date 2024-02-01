using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Coding.Exam.RainFallAPI.Controllers
{
	[ApiController]
	[Route("[controller]/")]
	public class RainFallController : ControllerBase
	{
		private readonly ILogger<RainFallController> _logger;
		public RainFallController(ILogger<RainFallController> logger)
        {
			_logger = logger;
		}

		
		[HttpGet("id/{stationId}/readings")]
		public async Task<ActionResult> Get(int stationId)
		{
			return Ok();
		}
	}
}
