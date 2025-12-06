using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Adapters.Database.Eloquent.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cellphone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Imei = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Inches = table.Column<double>(type: "float", nullable: false),
                    Megapixels = table.Column<double>(type: "float", nullable: false),
                    CamerasCount = table.Column<int>(type: "int", nullable: false),
                    RamGb = table.Column<int>(type: "int", nullable: false),
                    PrimaryStorageGb = table.Column<int>(type: "int", nullable: false),
                    SecondaryStorageGb = table.Column<int>(type: "int", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BandTechnology = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HasWifi = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HasBluetooth = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HasNfc = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HasFingerprint = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HasInfrared = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CpuBrand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CpuSpeedGhz = table.Column<double>(type: "float", nullable: false),
                    HasWaterResistance = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SimCount = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cellphone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cellphone_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cellphone_UserId",
                table: "Cellphone",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cellphones_Imei",
                table: "Cellphone",
                column: "Imei");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cellphone");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
