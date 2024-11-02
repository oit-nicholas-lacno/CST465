using Microsoft.AspNetCore.Mvc;

[Route("Contact")]
public class ContactController : Controller
{
    [Route("HTML")]
    [HttpGet]
    public ActionResult ContactHtml()
    {
        ViewBag.Title = "Contact - HTML";
        return View(new ContactFormModel());
    }

    [Route("")]
    [HttpGet]
    public ActionResult ContactTagHelper()
    {
        ViewBag.Title = "Contact - Tag Helper";
        return View(new ContactFormModel());
    }

    [Route("Result")]
    [Route("ContactHTML/Result")]
    [HttpPost]
    public IActionResult ContactResult(ContactFormModel model)
    {
        ViewBag.Title = "Contact Result";
        return View("ContactResult", model);
    }
}