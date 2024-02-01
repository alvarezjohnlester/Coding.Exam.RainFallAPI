using Coding.Exam.RainFallAPI.Configuration;
using Coding.Exam.RainFallAPI.Controllers;
using Coding.Exam.RainFallAPI.Interface;
using Coding.Exam.RainFallAPI.Models;
using Microsoft.Extensions.Options;

namespace Coding.Exam.RainFallAPI.Service
{
	public class RainFallService : IRainFallService
	{
		private readonly ILogger<RainFallService> _logger;
		private readonly RainFallConfig _rainFallConfig;
		public RainFallService(ILogger<RainFallService> logger, IOptions<RainFallConfig> options)
        {
			_logger = logger;
			_rainFallConfig = options.Value;
		}

		public async Task<RainFallReadingResponse> GetRainFallReading(int stationId, int limit)
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync($"{_rainFallConfig.BaseUrl}/id/stations/{stationId}/readings?_sorted&_limit={limit}");
			if (response.IsSuccessStatusCode)
			{
				string resp = await  response.Content.ReadAsStringAsync();
			}

			return new RainFallReadingResponse { };
		}
	}
}
