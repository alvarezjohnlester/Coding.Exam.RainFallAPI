namespace Coding.Exam.RainFallAPI.Models
{
	public class RainFallReadingResponse
	{
        public List<RainFallMeasure> items { get; set; }
	}
	public class RainFallMeasure
	{
        public string @id { get; set; }
        public DateTime dateTime { get; set; }
        public string measure { get; set; }
        public string value { get; set; }
    }

}
