using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Validation;

[Route("Error")]
public class ErrorController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        int statusCode = HttpContext.Response.StatusCode;
        if (statusCode == 500)
            return View("Error500");
        else if (statusCode == 404)
            return View("Error404");
        
        return View(statusCode);
    }
}