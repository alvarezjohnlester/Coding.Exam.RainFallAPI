using Microsoft.AspNetCore.Mvc;

namespace Coding.Exam.RainFallAPI.Controllers
{
	public class RainFallController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
