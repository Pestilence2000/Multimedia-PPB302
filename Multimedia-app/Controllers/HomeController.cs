using Microsoft.AspNetCore.Mvc;

namespace Multimedia_app.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}