namespace Multimedia_app.Models;

public class Artwork
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public byte[]? AudioFile { get; set; }
    public string? AudioContentType { get; set; }
    public string? AudioFileName { get; set; }

    public byte[]? TextFile { get; set; }
    public string? TextContentType { get; set; }
    public string? TextFileName { get; set; }
    
    public string? TextContent { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}