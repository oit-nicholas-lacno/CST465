using Microsoft.AspNetCore.Mvc;

[Route("")]
[Route("Home")]
public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}