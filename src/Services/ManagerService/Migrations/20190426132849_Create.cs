using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerService.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "manager");

            migrationBuilder.CreateTable(
                name: "violateUser",
                schema: "manager",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsWarned = table.Column<bool>(type: "bit", nullable: false),
                    IsInBlackMenu = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<Guid>(type: "Uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_violateUser", x => x.PkId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_violateUser_Name",
                schema: "manager",
                table: "violateUser",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "violateUser",
                schema: "manager");
        }
    }
}
