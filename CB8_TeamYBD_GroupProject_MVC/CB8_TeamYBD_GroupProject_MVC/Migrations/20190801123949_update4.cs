using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CB8_TeamYBD_GroupProject_MVC.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LikeDateTime",
                table: "CommentLikes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeDateTime",
                table: "CommentLikes");
        }
    }
}
