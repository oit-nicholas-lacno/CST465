using Microsoft.AspNetCore.Mvc;

namespace Lab9
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/Home/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
