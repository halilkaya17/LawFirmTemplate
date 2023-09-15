using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawFirmTemplate.Migrations
{
    /// <inheritdoc />
    public partial class homePageEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slider",
                table: "HomePages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slider",
                table: "HomePages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
