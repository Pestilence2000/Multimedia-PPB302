using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multimedia_app.Migrations
{
    /// <inheritdoc />
    public partial class AddTextContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TextContent",
                table: "Artworks",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TextContent",
                table: "Artworks");
        }
    }
}
