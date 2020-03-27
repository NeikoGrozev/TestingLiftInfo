using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingLiftInfo.Data.Migrations
{
    public partial class UpdateInspectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Inspects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inspects_ApplicationUserId",
                table: "Inspects",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspects_AspNetUsers_ApplicationUserId",
                table: "Inspects",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspects_AspNetUsers_ApplicationUserId",
                table: "Inspects");

            migrationBuilder.DropIndex(
                name: "IX_Inspects_ApplicationUserId",
                table: "Inspects");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Inspects");
        }
    }
}
