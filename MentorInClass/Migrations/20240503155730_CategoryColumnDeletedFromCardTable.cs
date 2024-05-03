using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorInClass.Migrations
{
    /// <inheritdoc />
    public partial class CategoryColumnDeletedFromCardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Cards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
