using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab8.Models;
using Lab8.Repositories;
using Lab8.DataObjects;
using Microsoft.AspNetCore.OutputCaching;

namespace Lab8.Controllers;
[Route("")]
[Route("Home")]
public class HomeController : Controller
{
    private readonly IImageRepository _ImageRepo;

    public HomeController(IImageRepository imageRepo)
    {
        _ImageRepo = imageRepo;
    }
    [Route("")]
    [HttpGet("Index")]
    [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, NoStore= false)]
    [OutputCache]
    public IActionResult Index()
    {
        return View(_ImageRepo.GetImages());
    }

    [HttpGet]
    public IActionResult AddImage()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddImage(ImageModel image)
    {
        if (!ModelState.IsValid)
        {
            return View(image);
        }
        
        ImageObject img = new ImageObject();
        using MemoryStream fileStream = new MemoryStream();

        image.ImageFile.CopyTo(fileStream);
        img.FileData = fileStream.ToArray();

        img.FileName = image.ImageFile.FileName;
        img.Description = image.Description;

        _ImageRepo.SaveImage(img);
        return View(image);
    }

    [HttpGet("/Image/{id}")]
    public IActionResult GetImage(int id)
    {
        return File(_ImageRepo.GetImageData(id), "image/jpeg");
    }
}
