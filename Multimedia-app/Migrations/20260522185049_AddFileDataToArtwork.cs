using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multimedia_app.Migrations
{
    /// <inheritdoc />
    public partial class AddFileDataToArtwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TextFilePath",
                table: "Artworks",
                newName: "TextFileName");

            migrationBuilder.RenameColumn(
                name: "AudioFilePath",
                table: "Artworks",
                newName: "TextContentType");

            migrationBuilder.AddColumn<string>(
                name: "AudioContentType",
                table: "Artworks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "AudioFile",
                table: "Artworks",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AudioFileName",
                table: "Artworks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "TextFile",
                table: "Artworks",
                type: "BLOB",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioContentType",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "AudioFile",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "AudioFileName",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "TextFile",
                table: "Artworks");

            migrationBuilder.RenameColumn(
                name: "TextFileName",
                table: "Artworks",
                newName: "TextFilePath");

            migrationBuilder.RenameColumn(
                name: "TextContentType",
                table: "Artworks",
                newName: "AudioFilePath");
        }
    }
}
