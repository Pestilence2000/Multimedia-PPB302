using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Multimedia_app.Controllers;

public class AdminController : Controller
{
    /*private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var artworks = await _context.Artworks
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();

        return View(artworks);
    }*/
    public IActionResult Index()
    {
        return View();
    }
}