using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQL_Lab_2.Migrations;

/// <inheritdoc />
public partial class Allow_Composer_Null : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Composer",
            table: "Tracks",
            type: "nvarchar(220)",
            maxLength: 220,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(220)",
            oldMaxLength: 220);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "Composer",
            table: "Tracks",
            type: "nvarchar(220)",
            maxLength: 220,
            nullable: false,
            defaultValue: "",
            oldClrType: typeof(string),
            oldType: "nvarchar(220)",
            oldMaxLength: 220,
            oldNullable: true);
    }
}
