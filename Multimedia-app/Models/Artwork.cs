namespace Multimedia_app.Models;

public class Artwork
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? AudioFilePath { get; set; }
    public string? TextFilePath { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}