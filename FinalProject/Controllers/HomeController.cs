using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FinalProject.DataObjects;
using NuGet.ContentModel;
using System.Text.Json;
using System.Linq;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/")]
        [Route("/Index")]
        public IActionResult Index()
        {
            PlannerModel planner = new();
            if (Request.Cookies[nameof(Planner)] is not null)
            {
                planner = JsonSerializer.Deserialize<Planner>(Request.Cookies[nameof(Planner)]).ToModel();
            }
            else
            {
                var json = JsonSerializer.Serialize(planner.ToDataObject());
                Response.Cookies.Append(nameof(Planner), json, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddMinutes(30)
                });
            }

            return View(planner);
        }

        [HttpGet]
        [Route("/NewTask")]
        public IActionResult AddTask()
        {
            TaskModel model = new();

            return View(model);
        }

        [HttpPost]
        [Route("/NewTask")]
        public IActionResult AddTask(TaskModel model)
        {
            ModelState["TaskStatus"].ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.TaskStatus = "NotStarted";
            //add task to list and cookies here
            var task = model.ToDataObject();
            task.Due = task.Due.ToUniversalTime();

            Planner planner = new();
            if (Request.Cookies[nameof(Planner)] is not null)
            {
                planner = JsonSerializer.Deserialize<Planner>(Request.Cookies[nameof(Planner)]);
            }
            planner.AddTask(task);
            var json = JsonSerializer.Serialize(planner);
            Response.Cookies.Append(nameof(Planner), json, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddMinutes(30)
            });

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
