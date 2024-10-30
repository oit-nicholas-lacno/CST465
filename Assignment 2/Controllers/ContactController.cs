using Microsoft.AspNetCore.Mvc;

namespace Contact;

[Route("Contact")]
public class ContactController : Controller
{
    [Route("ContactHtml")]
    [HttpGet]
    public ActionResult ContactHtml()
    {
        return View();
    }

    [Route("ContactTagHelper")]
    [HttpGet]
    public ActionResult ContactTagHelper()
    {
        return View();
    }

    [Route("Result")]
    [HttpPost]
    public IActionResult ContactResult(Contact.ContactFormModel model)
    {
        return View("ContactResult",model);
    }
}