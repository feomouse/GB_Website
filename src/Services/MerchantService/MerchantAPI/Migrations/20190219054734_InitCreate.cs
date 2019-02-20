using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MerchantAPI.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "merchant");

            migrationBuilder.CreateTable(
                name: "MerchantIdentity",
                schema: "merchant",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    IdentityName = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    IdentityNum = table.Column<string>(type: "varchar(18)", nullable: true),
                    IdentityImgF = table.Column<string>(type: "varchar(50)", nullable: true),
                    IdentityImgB = table.Column<string>(type: "varchar(50)", nullable: true),
                    LicenseImg = table.Column<string>(type: "varchar(50)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "MerchantBasic",
                schema: "merchant",
                columns: table => new
                {
                    AuthPkId = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityPkId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantBasic", x => x.AuthPkId);
                    table.ForeignKey(
                        name: "FK_MerchantBasic_MerchantIdentity_IdentityPkId",
                        column: x => x.IdentityPkId,
                        principalSchema: "merchant",
                        principalTable: "MerchantIdentity",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MerchantBasic_IdentityPkId",
                schema: "merchant",
                table: "MerchantBasic",
                column: "IdentityPkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MerchantBasic",
                schema: "merchant");

            migrationBuilder.DropTable(
                name: "MerchantIdentity",
                schema: "merchant");
        }
    }
}
