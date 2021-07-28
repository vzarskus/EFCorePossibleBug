using Microsoft.EntityFrameworkCore.Migrations;

namespace BugReproduction.Migrations
{
    public partial class ScoreComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Score_DeliveryTypeScore",
                table: "Offers",
                type: "FLOAT(53)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Score_RandomScore",
                table: "Offers",
                type: "FLOAT(53)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Score_RatingScore",
                table: "Offers",
                type: "FLOAT(53)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score_DeliveryTypeScore",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Score_RandomScore",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Score_RatingScore",
                table: "Offers");
        }
    }
}
