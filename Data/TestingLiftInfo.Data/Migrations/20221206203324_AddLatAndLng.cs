using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingLiftInfo.Data.Migrations
{
    public partial class AddLatAndLng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Lifts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Lifts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Lifts");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Lifts");
        }
    }
}
