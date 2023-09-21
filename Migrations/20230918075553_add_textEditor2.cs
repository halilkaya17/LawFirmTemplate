using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirmTemplate.Migrations
{
    /// <inheritdoc />
    public partial class add_textEditor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Paragraph2",
                table: "AboutUs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paragraph2",
                table: "AboutUs");
        }
    }
}
