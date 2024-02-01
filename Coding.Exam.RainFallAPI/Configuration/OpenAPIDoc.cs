namespace Coding.Exam.RainFallAPI.Configuration
{
	public class OpenAPIDoc
	{
        public Contract Contract { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
    }
	public class Contract 
	{ 
		public string Name { get; set; }
		public string Url { get; set; }
	}

}
