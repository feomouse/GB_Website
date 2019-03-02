using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAPI.Migrations
{
    public partial class initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shop");

            migrationBuilder.CreateTable(
                name: "shop",
                schema: "shop",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    Tel = table.Column<string>(type: "varchar(11)", nullable: true),
                    RegisterId = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    Pic = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "GBProduct",
                schema: "shop",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    OrinPrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    VailSDate = table.Column<DateTime>(type: "date", nullable: false),
                    VailEDate = table.Column<DateTime>(type: "date", nullable: false),
                    VailTime = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Img = table.Column<string>(type: "varchar(50)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GBProduct", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_GBProduct_shop_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "shop",
                        principalTable: "shop",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                schema: "shop",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    ShopId = table.Column<Guid>(nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_ProductType_shop_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "shop",
                        principalTable: "shop",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GBProductItem",
                schema: "shop",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    GbProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GbItemName = table.Column<string>(nullable: true),
                    GbItemImg = table.Column<string>(nullable: true),
                    GbItemPrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GBProductItem", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_GBProductItem_GBProduct_GbProductId",
                        column: x => x.GbProductId,
                        principalSchema: "shop",
                        principalTable: "GBProduct",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GBRule",
                schema: "shop",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    GBProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GBRule", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_GBRule_GBProduct_GBProductId",
                        column: x => x.GBProductId,
                        principalSchema: "shop",
                        principalTable: "GBProduct",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "shop",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ProductTypeId = table.Column<Guid>(nullable: false),
                    ProductImg = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProductPrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    MSellNum = table.Column<short>(type: "smallint", nullable: false),
                    PraiseNum = table.Column<short>(type: "smallint", nullable: false),
                    IsDisplay = table.Column<bool>(type: "bit", nullable: false),
                    ShopId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "shop",
                        principalTable: "ProductType",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GBProduct_ShopId",
                schema: "shop",
                table: "GBProduct",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_GBProductItem_GbProductId",
                schema: "shop",
                table: "GBProductItem",
                column: "GbProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GBRule_GBProductId",
                schema: "shop",
                table: "GBRule",
                column: "GBProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                schema: "shop",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ShopId",
                schema: "shop",
                table: "ProductType",
                column: "ShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GBProductItem",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "GBRule",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "GBProduct",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "ProductType",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "shop",
                schema: "shop");
        }
    }
}
