using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderAPI.Migrations
{
    public partial class initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.CreateTable(
                name: "OrderBasic",
                schema: "order",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    CustomerPkId = table.Column<Guid>(nullable: false),
                    ShopPkId = table.Column<Guid>(nullable: false),
                    Remark = table.Column<string>(type: "varchar(50)", nullable: true),
                    Address = table.Column<string>(type: "varchar(50)", nullable: true),
                    Sender = table.Column<string>(type: "varchar(10)", nullable: true),
                    TotalCost = table.Column<short>(type: "smallint", nullable: false),
                    Evaluate = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBasic", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                schema: "order",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    PayWay = table.Column<int>(type: "int", nullable: false),
                    CpkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    BasicOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_OrderBasic_BasicOrderId",
                        column: x => x.BasicOrderId,
                        principalSchema: "order",
                        principalTable: "OrderBasic",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                schema: "order",
                columns: table => new
                {
                    PpkId = table.Column<Guid>(nullable: false),
                    SpkId = table.Column<Guid>(nullable: false),
                    OpkId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.PpkId, x.SpkId, x.OpkId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_OrderBasic_OpkId",
                        column: x => x.OpkId,
                        principalSchema: "order",
                        principalTable: "OrderBasic",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopOrder",
                schema: "order",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    SpkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasicOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrder", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_ShopOrder_OrderBasic_BasicOrderId",
                        column: x => x.BasicOrderId,
                        principalSchema: "order",
                        principalTable: "OrderBasic",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_BasicOrderId",
                schema: "order",
                table: "CustomerOrder",
                column: "BasicOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OpkId",
                schema: "order",
                table: "OrderProduct",
                column: "OpkId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrder_BasicOrderId",
                schema: "order",
                table: "ShopOrder",
                column: "BasicOrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrder",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderProduct",
                schema: "order");

            migrationBuilder.DropTable(
                name: "ShopOrder",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderBasic",
                schema: "order");
        }
    }
}
