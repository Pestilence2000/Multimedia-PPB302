using Microsoft.AspNetCore.Mvc;
using Multimedia_app.Models;
using DocumentFormat.OpenXml.Packaging;
using UglyToad.PdfPig;

namespace Multimedia_app.Controllers;

public class CreateController : Controller
{
    private readonly ArtDbContext _context;

    public CreateController(ArtDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new Artwork());
    }

    [HttpPost]
    public async Task<IActionResult> Index(
        Artwork artwork,
        IFormFile? audioFile,
        IFormFile? textFile)
    {
        if (audioFile != null && audioFile.Length > 0)
        {
            using var memoryStream = new MemoryStream();
            await audioFile.CopyToAsync(memoryStream);

            artwork.AudioFile = memoryStream.ToArray();
            artwork.AudioContentType = audioFile.ContentType;
            artwork.AudioFileName = audioFile.FileName;
        }

        if (textFile != null && textFile.Length > 0)
        {
            using var memoryStream = new MemoryStream();
            await textFile.CopyToAsync(memoryStream);

            artwork.TextFile = memoryStream.ToArray();
            artwork.TextContentType = textFile.ContentType;
            artwork.TextFileName = textFile.FileName;

            memoryStream.Position = 0;

            var extension = Path.GetExtension(textFile.FileName).ToLower();

            if (extension == ".txt")
            {
                using var reader = new StreamReader(memoryStream);
                artwork.TextContent = await reader.ReadToEndAsync();
            }
            else if (extension == ".pdf")
            {
                using var document = PdfDocument.Open(memoryStream);

                artwork.TextContent = string.Join("\n\n", document.GetPages().Select(p => p.Text));
            }
            else if (extension == ".docx")
            {
                using var wordDoc = WordprocessingDocument.Open(memoryStream, false);

                artwork.TextContent =
                    wordDoc.MainDocumentPart?.Document.Body?.InnerText;
            }
        }

        artwork.CreatedAt = DateTime.Now;

        _context.Artworks.Add(artwork);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }
}