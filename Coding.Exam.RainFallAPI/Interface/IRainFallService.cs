using Coding.Exam.RainFallAPI.Models;

namespace Coding.Exam.RainFallAPI.Interface
{
	public interface IRainFallService
	{
		Task<RainFallReadingResponse> GetRainFallReading(int stationId, int limit);
	}
}
