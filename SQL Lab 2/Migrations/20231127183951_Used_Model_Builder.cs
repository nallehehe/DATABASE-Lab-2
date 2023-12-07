using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQL_Lab_2.Migrations;

/// <inheritdoc />
public partial class Used_Model_Builder : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_PlaylistTracks",
            table: "PlaylistTracks");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Tracks",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(200)",
            oldMaxLength: 200);

        migrationBuilder.AlterColumn<string>(
            name: "Composer",
            table: "Tracks",
            type: "nvarchar(max)",
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(220)",
            oldMaxLength: 220,
            oldNullable: true);

        migrationBuilder.AddColumn<int>(
            name: "Id",
            table: "PlaylistTracks",
            type: "int",
            nullable: false,
            defaultValue: 0)
            .Annotation("SqlServer:Identity", "1, 1");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Playlists",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(120)",
            oldMaxLength: 120);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "MediaTypes",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(120)",
            oldMaxLength: 120);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Genres",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(120)",
            oldMaxLength: 120);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Artists",
            type: "nvarchar(max)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(120)",
            oldMaxLength: 120);

        migrationBuilder.AddPrimaryKey(
            name: "PK_PlaylistTracks",
            table: "PlaylistTracks",
            column: "Id");

        migrationBuilder.CreateIndex(
            name: "IX_PlaylistTracks_PlaylistId",
            table: "PlaylistTracks",
            column: "PlaylistId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropPrimaryKey(
            name: "PK_PlaylistTracks",
            table: "PlaylistTracks");

        migrationBuilder.DropIndex(
            name: "IX_PlaylistTracks_PlaylistId",
            table: "PlaylistTracks");

        migrationBuilder.DropColumn(
            name: "Id",
            table: "PlaylistTracks");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Tracks",
            type: "nvarchar(200)",
            maxLength: 200,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Composer",
            table: "Tracks",
            type: "nvarchar(220)",
            maxLength: 220,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)",
            oldNullable: true);

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Playlists",
            type: "nvarchar(120)",
            maxLength: 120,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "MediaTypes",
            type: "nvarchar(120)",
            maxLength: 120,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Genres",
            type: "nvarchar(120)",
            maxLength: 120,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AlterColumn<string>(
            name: "Name",
            table: "Artists",
            type: "nvarchar(120)",
            maxLength: 120,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(max)");

        migrationBuilder.AddPrimaryKey(
            name: "PK_PlaylistTracks",
            table: "PlaylistTracks",
            columns: new[] { "PlaylistId", "TrackId" });
    }
}
