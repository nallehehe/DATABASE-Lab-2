using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQL_Lab_2.Migrations;

/// <inheritdoc />
public partial class Made_PlaylistId_TrackId_Into_Primary : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Id",
            table: "PlaylistTracks");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "Id",
            table: "PlaylistTracks",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }
}
