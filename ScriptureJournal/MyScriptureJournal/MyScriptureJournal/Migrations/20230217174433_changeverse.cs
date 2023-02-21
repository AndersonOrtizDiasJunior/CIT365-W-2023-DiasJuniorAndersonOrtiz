using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyScriptureJournal.Migrations
{
    /// <inheritdoc />
    public partial class changeverse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalVerse",
                table: "Entry");

            migrationBuilder.DropColumn(
                name: "InitialVerse",
                table: "Entry");

            migrationBuilder.AddColumn<string>(
                name: "Verses",
                table: "Entry",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verses",
                table: "Entry");

            migrationBuilder.AddColumn<int>(
                name: "FinalVerse",
                table: "Entry",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InitialVerse",
                table: "Entry",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
