namespace TestingLiftInfo.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportCompanies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lifts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    LiftType = table.Column<int>(nullable: false),
                    NumberOfStops = table.Column<int>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    DoorType = table.Column<int>(nullable: false),
                    RegistrationNumber = table.Column<string>(nullable: false),
                    ManufacturerId = table.Column<string>(nullable: true),
                    CityId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    SupportCompanyId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lifts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lifts_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lifts_SupportCompanies_SupportCompanyId",
                        column: x => x.SupportCompanyId,
                        principalTable: "SupportCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inspects",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    InspectTypeId = table.Column<string>(nullable: true),
                    LiftId = table.Column<string>(nullable: true),
                    SupportCompanyId = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Prescriptions = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspects_InspectTypes_InspectTypeId",
                        column: x => x.InspectTypeId,
                        principalTable: "InspectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspects_Lifts_LiftId",
                        column: x => x.LiftId,
                        principalTable: "Lifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspects_SupportCompanies_SupportCompanyId",
                        column: x => x.SupportCompanyId,
                        principalTable: "SupportCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IsDeleted",
                table: "Cities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Inspects_InspectTypeId",
                table: "Inspects",
                column: "InspectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspects_IsDeleted",
                table: "Inspects",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Inspects_LiftId",
                table: "Inspects",
                column: "LiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspects_SupportCompanyId",
                table: "Inspects",
                column: "SupportCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectTypes_IsDeleted",
                table: "InspectTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Lifts_CityId",
                table: "Lifts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Lifts_IsDeleted",
                table: "Lifts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Lifts_ManufacturerId",
                table: "Lifts",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Lifts_SupportCompanyId",
                table: "Lifts",
                column: "SupportCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_IsDeleted",
                table: "Manufacturers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SupportCompanies_IsDeleted",
                table: "SupportCompanies",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspects");

            migrationBuilder.DropTable(
                name: "InspectTypes");

            migrationBuilder.DropTable(
                name: "Lifts");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "SupportCompanies");
        }
    }
}
