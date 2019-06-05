﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shop");

            migrationBuilder.CreateTable(
                name: "shopType",
                schema: "shop",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopType", x => x.PkId);
                });

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
                    ShopTypePkId = table.Column<Guid>(nullable: false),
                    Tel = table.Column<string>(type: "varchar(11)", nullable: true),
                    RegisterId = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    IsIdentitied = table.Column<bool>(type: "bit", nullable: false),
                    GroupBuying = table.Column<bool>(type: "bit", nullable: false),
                    OwnMoney = table.Column<int>(type: "int", nullable: false),
                    WorkingTime = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_shop_shopType_ShopTypePkId",
                        column: x => x.ShopTypePkId,
                        principalSchema: "shop",
                        principalTable: "shopType",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "monthSell",
                schema: "shop",
                columns: table => new
                {
                    MShopId = table.Column<Guid>(nullable: false),
                    Year = table.Column<string>(type: "varchar(4)", nullable: false),
                    Month = table.Column<string>(type: "varchar(2)", nullable: false),
                    Num = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monthSell", x => new { x.MShopId, x.Year, x.Month });
                    table.ForeignKey(
                        name: "FK_monthSell_shop_MShopId",
                        column: x => x.MShopId,
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
                name: "shopImg",
                schema: "shop",
                columns: table => new
                {
                    MShopId = table.Column<Guid>(nullable: false),
                    Img = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopImg", x => new { x.MShopId, x.Img });
                    table.ForeignKey(
                        name: "FK_shopImg_shop_MShopId",
                        column: x => x.MShopId,
                        principalSchema: "shop",
                        principalTable: "shop",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visitNum",
                schema: "shop",
                columns: table => new
                {
                    MShopId = table.Column<Guid>(nullable: false),
                    Year = table.Column<string>(type: "varchar(4)", nullable: false),
                    Month = table.Column<string>(type: "varchar(2)", nullable: false),
                    Num = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitNum", x => new { x.MShopId, x.Year, x.Month });
                    table.ForeignKey(
                        name: "FK_visitNum_shop_MShopId",
                        column: x => x.MShopId,
                        principalSchema: "shop",
                        principalTable: "shop",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GBProduct",
                schema: "shop",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    OrinPrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    VailSDate = table.Column<DateTime>(type: "date", nullable: false),
                    VailEDate = table.Column<DateTime>(type: "date", nullable: false),
                    VailTime = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    IsDisplay = table.Column<bool>(type: "bit", nullable: false),
                    PraiseNum = table.Column<int>(type: "int", nullable: false),
                    MSellNum = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ProductTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GBProduct", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_GBProduct_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "shop",
                        principalTable: "ProductType",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gbProductImg",
                schema: "shop",
                columns: table => new
                {
                    MGBProductId = table.Column<Guid>(nullable: false),
                    Img = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gbProductImg", x => new { x.MGBProductId, x.Img });
                    table.ForeignKey(
                        name: "FK_gbProductImg_GBProduct_MGBProductId",
                        column: x => x.MGBProductId,
                        principalSchema: "shop",
                        principalTable: "GBProduct",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GBProduct_ProductTypeId",
                schema: "shop",
                table: "GBProduct",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ShopId",
                schema: "shop",
                table: "ProductType",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_shop_ShopTypePkId",
                schema: "shop",
                table: "shop",
                column: "ShopTypePkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gbProductImg",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "monthSell",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "shopImg",
                schema: "shop");

            migrationBuilder.DropTable(
                name: "visitNum",
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

            migrationBuilder.DropTable(
                name: "shopType",
                schema: "shop");
        }
    }
}