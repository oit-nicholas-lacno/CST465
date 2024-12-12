using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FinalProject.DataObjects;

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
        public IActionResult Index()
        {
            return View();
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
            model = task.ToModel();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
