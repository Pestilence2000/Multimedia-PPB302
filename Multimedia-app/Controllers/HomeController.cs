using Microsoft.AspNetCore.Mvc;
using Multimedia_app.Models;

namespace Multimedia_app.Controllers;

public class HomeController : Controller
{
    private readonly ArtDbContext _context;

    public HomeController(ArtDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var artworks = _context.Artworks.ToList();
        return View(artworks);
    }
}