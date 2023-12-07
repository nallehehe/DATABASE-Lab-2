using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQL_Lab_2.Migrations;

/// <inheritdoc />
public partial class firstmigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Artists",
            columns: table => new
            {
                ArtistId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Artists", x => x.ArtistId);
            });

        migrationBuilder.CreateTable(
            name: "Genres",
            columns: table => new
            {
                GenreId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Genres", x => x.GenreId);
            });

        migrationBuilder.CreateTable(
            name: "MediaTypes",
            columns: table => new
            {
                MediaTypeId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MediaTypes", x => x.MediaTypeId);
            });

        migrationBuilder.CreateTable(
            name: "Playlists",
            columns: table => new
            {
                PlaylistId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Playlists", x => x.PlaylistId);
            });

        migrationBuilder.CreateTable(
            name: "Albums",
            columns: table => new
            {
                AlbumId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                ArtistId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Albums", x => x.AlbumId);
                table.ForeignKey(
                    name: "FK_Albums_Artists_ArtistId",
                    column: x => x.ArtistId,
                    principalTable: "Artists",
                    principalColumn: "ArtistId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Tracks",
            columns: table => new
            {
                TrackID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Composer = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: false),
                Milliseconds = table.Column<int>(type: "int", nullable: false),
                Bytes = table.Column<int>(type: "int", nullable: false),
                UnitPrice = table.Column<double>(type: "float", nullable: false),
                AlbumId = table.Column<int>(type: "int", nullable: false),
                MediaTypeId = table.Column<int>(type: "int", nullable: false),
                GenreId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tracks", x => x.TrackID);
                table.ForeignKey(
                    name: "FK_Tracks_Albums_AlbumId",
                    column: x => x.AlbumId,
                    principalTable: "Albums",
                    principalColumn: "AlbumId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Tracks_Genres_GenreId",
                    column: x => x.GenreId,
                    principalTable: "Genres",
                    principalColumn: "GenreId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Tracks_MediaTypes_MediaTypeId",
                    column: x => x.MediaTypeId,
                    principalTable: "MediaTypes",
                    principalColumn: "MediaTypeId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "PlaylistTracks",
            columns: table => new
            {
                PlaylistId = table.Column<int>(type: "int", nullable: false),
                TrackId = table.Column<int>(type: "int", nullable: false),
                Id = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PlaylistTracks", x => new { x.PlaylistId, x.TrackId });
                table.ForeignKey(
                    name: "FK_PlaylistTracks_Playlists_PlaylistId",
                    column: x => x.PlaylistId,
                    principalTable: "Playlists",
                    principalColumn: "PlaylistId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_PlaylistTracks_Tracks_TrackId",
                    column: x => x.TrackId,
                    principalTable: "Tracks",
                    principalColumn: "TrackID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Albums_ArtistId",
            table: "Albums",
            column: "ArtistId");

        migrationBuilder.CreateIndex(
            name: "IX_PlaylistTracks_TrackId",
            table: "PlaylistTracks",
            column: "TrackId");

        migrationBuilder.CreateIndex(
            name: "IX_Tracks_AlbumId",
            table: "Tracks",
            column: "AlbumId");

        migrationBuilder.CreateIndex(
            name: "IX_Tracks_GenreId",
            table: "Tracks",
            column: "GenreId");

        migrationBuilder.CreateIndex(
            name: "IX_Tracks_MediaTypeId",
            table: "Tracks",
            column: "MediaTypeId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "PlaylistTracks");

        migrationBuilder.DropTable(
            name: "Playlists");

        migrationBuilder.DropTable(
            name: "Tracks");

        migrationBuilder.DropTable(
            name: "Albums");

        migrationBuilder.DropTable(
            name: "Genres");

        migrationBuilder.DropTable(
            name: "MediaTypes");

        migrationBuilder.DropTable(
            name: "Artists");
    }
}
