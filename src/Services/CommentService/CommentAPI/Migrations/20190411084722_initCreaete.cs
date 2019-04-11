using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommentAPI.Migrations
{
    public partial class initCreaete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "comment");

            migrationBuilder.CreateTable(
                name: "UserComment",
                schema: "comment",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "varchar(100)", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComment", x => x.PkId);
                });

            migrationBuilder.CreateTable(
                name: "ReplyComment",
                schema: "comment",
                columns: table => new
                {
                    PkId = table.Column<Guid>(nullable: false),
                    CommentId = table.Column<Guid>(nullable: false),
                    Reply = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyComment", x => x.PkId);
                    table.ForeignKey(
                        name: "FK_ReplyComment_UserComment_CommentId",
                        column: x => x.CommentId,
                        principalSchema: "comment",
                        principalTable: "UserComment",
                        principalColumn: "PkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReplyComment_CommentId",
                schema: "comment",
                table: "ReplyComment",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReplyComment",
                schema: "comment");

            migrationBuilder.DropTable(
                name: "UserComment",
                schema: "comment");
        }
    }
}
