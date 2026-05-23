using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multimedia_app.Models;

namespace Multimedia_app.Controllers;

public class AdminController : Controller
{
    private readonly ArtDbContext _context;

    public AdminController(ArtDbContext context)
    {
        _context = context;
    }

    /*--------------------------------- Läs funktion ---------------------------------*/
    
    public async Task<IActionResult> Index()
    {
        var artworks = await _context.Artworks
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();

        return View(artworks);
    }
    
    
    /*---------------------------------Ta bort funktion ---------------------------------*/
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var artwork = await _context.Artworks.FindAsync(id);

        if (artwork == null)
        {
            return NotFound();
        }

        _context.Artworks.Remove(artwork);

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}