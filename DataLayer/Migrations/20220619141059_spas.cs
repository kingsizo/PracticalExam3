using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class spas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriversLicenses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EGN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriversLicenses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KATs",
                columns: table => new
                {
                    KatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KATs", x => x.KatID);
                });

            migrationBuilder.CreateTable(
                name: "LicensePlates",
                columns: table => new
                {
                    PlateNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlateType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DateOfRegistration = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RegistratedInKatKatID = table.Column<int>(type: "int", nullable: false),
                    RegistratorPlateNumber = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicensePlates", x => x.PlateNumber);
                    table.ForeignKey(
                        name: "FK_LicensePlates_KATs_RegistratedInKatKatID",
                        column: x => x.RegistratedInKatKatID,
                        principalTable: "KATs",
                        principalColumn: "KatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicensePlates_LicensePlates_RegistratorPlateNumber",
                        column: x => x.RegistratorPlateNumber,
                        principalTable: "LicensePlates",
                        principalColumn: "PlateNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicensePlates_RegistratedInKatKatID",
                table: "LicensePlates",
                column: "RegistratedInKatKatID");

            migrationBuilder.CreateIndex(
                name: "IX_LicensePlates_RegistratorPlateNumber",
                table: "LicensePlates",
                column: "RegistratorPlateNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriversLicenses");

            migrationBuilder.DropTable(
                name: "LicensePlates");

            migrationBuilder.DropTable(
                name: "KATs");
        }
    }
}
