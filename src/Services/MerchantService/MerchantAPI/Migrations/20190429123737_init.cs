using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchantAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "merchant");

            migrationBuilder.CreateTable(
                name: "MerchantBasic",
                schema: "merchant",
                columns: table => new
                {
                    AuthPkId = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantBasic", x => x.AuthPkId);
                });

            migrationBuilder.CreateTable(
                name: "MerchantIdentity",
                schema: "merchant",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    IdentityName = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IdentityNum = table.Column<string>(type: "varchar(18)", nullable: true),
                    IdentityImgF = table.Column<string>(type: "varchar(100)", nullable: true),
                    IdentityImgB = table.Column<string>(type: "varchar(100)", nullable: true),
                    LicenseImg = table.Column<string>(type: "varchar(100)", nullable: true),
                    LicenseCode = table.Column<string>(type: "varchar(15)", nullable: true),
                    LicenseName = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    LicenseOwner = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    AvailableSatartTime = table.Column<DateTime>(type: "date", nullable: false),
                    AvailableTime = table.Column<DateTime>(type: "date", nullable: false),
                    Tel = table.Column<string>(type: "varchar(11)", nullable: true),
                    MerchantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantIdentity", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_MerchantIdentity_MerchantBasic_MerchantId",
                        column: x => x.MerchantId,
                        principalSchema: "merchant",
                        principalTable: "MerchantBasic",
                        principalColumn: "AuthPkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MerchantIdentity_MerchantId",
                schema: "merchant",
                table: "MerchantIdentity",
                column: "MerchantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchantIdentity",
                schema: "merchant");

            migrationBuilder.DropTable(
                name: "MerchantBasic",
                schema: "merchant");
        }
    }
}
