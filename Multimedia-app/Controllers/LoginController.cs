using Microsoft.AspNetCore.Mvc;

namespace Multimedia_app.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string email, string password)
    {
        if (email == "konstnar@test.se" && password == "1234")
        {
            return RedirectToAction("Index", "AdminArtwork");
        }

        ViewBag.Error = "Fel e-post eller lösenord.";
        return View();
    }
}