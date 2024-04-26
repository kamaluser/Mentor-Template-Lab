using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MentorInClass.Migrations
{
    /// <inheritdoc />
    public partial class NameColumnAddedToCardtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardFeature");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cards");

            migrationBuilder.CreateTable(
                name: "CardFeature",
                columns: table => new
                {
                    CardsId = table.Column<int>(type: "int", nullable: false),
                    FeaturesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFeature", x => new { x.CardsId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_CardFeature_Cards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardFeature_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardFeature_FeaturesId",
                table: "CardFeature",
                column: "FeaturesId");
        }
    }
}
