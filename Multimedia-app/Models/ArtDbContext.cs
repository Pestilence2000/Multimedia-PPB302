using Microsoft.EntityFrameworkCore;

namespace Multimedia_app.Models;

public class ArtDbContext : DbContext
{
    public ArtDbContext(DbContextOptions<ArtDbContext> options) : base(options)
    {
    }

    public DbSet<Artwork> Artworks { get; set; }
}