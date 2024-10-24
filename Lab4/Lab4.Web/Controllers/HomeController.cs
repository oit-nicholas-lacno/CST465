using Microsoft.AspNetCore.Mvc;
using Lab4.Objects;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    public IActionResult Laborers()
    {
        ChoreWorkforce cw = new();
        cw.Laborers.Add(new ChoreLaborer(){   Name = "Bob", Age = 7, Difficulty = 5 });
        cw.Laborers.Add(new ChoreLaborer(){   Name = "Frank", Age = 8, Difficulty = 3 });
        cw.Laborers.Add(new ChoreLaborer(){   Name = "Bill", Age = 9, Difficulty = 4 });
        cw.Laborers.Add(new ChoreLaborer(){   Name = "Joe", Age = 10, Difficulty = 1 });

        for (int i = 0; i < 30; i++)
        {
            cw.AddRandomLaborer();
        }

        List<ChoreLaborer> copy = new();
        foreach (ChoreLaborer laborer in cw.Laborers)
        {
            copy.Add(laborer);
        }
        var l = copy.Where(laborer => (laborer?.Age ?? -1) >= 3 && (laborer?.Age ?? -1) <= 10 && (laborer?.Difficulty ?? -1) <= 7).OrderBy(laborer => laborer.Name);
        cw.Laborers.Clear();
        foreach (var laborer in l)
        {
            cw.Laborers.Add(laborer);
        }

        return View(cw);
    }
}