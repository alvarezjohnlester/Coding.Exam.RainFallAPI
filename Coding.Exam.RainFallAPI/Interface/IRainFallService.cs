namespace Coding.Exam.RainFallAPI.Interface
{
	public interface IRainFallService
	{
		Task GetRainFallReading(int stationId, int limit);
	}
}
