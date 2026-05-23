using Microsoft.AspNetCore.Mvc;
using Multimedia_app.Models;

namespace Multimedia_app.Controllers;

public class ArtworkController: Controller
{
    private readonly ArtDbContext _context;

    public ArtworkController(ArtDbContext context)
    {
        _context = context;
    }
    
    /*------------------------------ Ljud funktion -----------------------------------*/
    public IActionResult Audio(int id)
    {
        var artwork = _context.Artworks.Find(id);

        if (artwork == null || artwork.AudioFile == null)
        {
            return NotFound();
        }

        return File(
            artwork.AudioFile,
            artwork.AudioContentType ?? "audio/mpeg"
        );
    }

    /*------------------------------ Text funktion -----------------------------------*/
    
    public IActionResult TextFile(int id)
    {
        var artwork = _context.Artworks.Find(id);

        if (artwork == null || artwork.TextFile == null)
            return NotFound();

        return File(
            artwork.TextFile,
            artwork.TextContentType ?? "application/octet-stream",
            artwork.TextFileName ?? "textfil"
        );
    }
    
    /*------------------------------ Visa upp specifikt innehåll -----------------------------------*/
    
    public IActionResult Index(int id)
    {
        var artwork = _context.Artworks.Find(id);

        if (artwork == null)
            return NotFound();

        return View(artwork);
    }
}