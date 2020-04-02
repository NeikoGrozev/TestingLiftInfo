namespace TestingLiftInfo.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UpdateApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Lifts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lifts_ApplicationUserId",
                table: "Lifts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lifts_AspNetUsers_ApplicationUserId",
                table: "Lifts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lifts_AspNetUsers_ApplicationUserId",
                table: "Lifts");

            migrationBuilder.DropIndex(
                name: "IX_Lifts_ApplicationUserId",
                table: "Lifts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Lifts");
        }
    }
}
