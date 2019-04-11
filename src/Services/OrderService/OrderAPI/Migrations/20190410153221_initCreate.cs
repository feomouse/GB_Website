using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderAPI.Migrations
{
    public partial class initCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.CreateTable(
                name: "GroupBuyingOrder",
                schema: "order",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    GroupProductName = table.Column<string>(type: "varchar(20)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false),
                    Evaluate = table.Column<string>(type: "varchar(36)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    OrderCode = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    PayWay = table.Column<int>(type: "int", nullable: false),
                    CpkId = table.Column<Guid>(type: "Uniqueidentifier", nullable: false),
                    SName = table.Column<string>(type: "varchar(20)", nullable: true),
                    Time = table.Column<DateTime>(type: "date", nullable: false),
                    Img = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupBuyingOrder", x => x.PkId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupBuyingOrder",
                schema: "order");
        }
    }
}
