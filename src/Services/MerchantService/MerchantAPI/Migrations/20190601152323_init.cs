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
                    AuthPkId = table.Column<Guid>(nullable: false)
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
                    MShopId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantIdentity", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "MerchantShops",
                schema: "merchant",
                columns: table => new
                {
                    MBasicId = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: false),
                    MIdentityId = table.Column<Guid>(nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantShops", x => new { x.MBasicId, x.ShopId });
                    table.ForeignKey(
                        name: "FK_MerchantShops_MerchantBasic_MBasicId",
                        column: x => x.MBasicId,
                        principalSchema: "merchant",
                        principalTable: "MerchantBasic",
                        principalColumn: "AuthPkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchantShops_MerchantIdentity_MIdentityId",
                        column: x => x.MIdentityId,
                        principalSchema: "merchant",
                        principalTable: "MerchantIdentity",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MerchantShops_MIdentityId",
                schema: "merchant",
                table: "MerchantShops",
                column: "MIdentityId",
                unique: true,
                filter: "[MIdentityId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchantShops",
                schema: "merchant");

            migrationBuilder.DropTable(
                name: "MerchantBasic",
                schema: "merchant");

            migrationBuilder.DropTable(
                name: "MerchantIdentity",
                schema: "merchant");
        }
    }
}
