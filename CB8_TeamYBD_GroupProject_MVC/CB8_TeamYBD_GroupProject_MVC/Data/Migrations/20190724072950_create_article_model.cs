using Microsoft.EntityFrameworkCore.Migrations;

namespace CB8_TeamYBD_GroupProject_MVC.Data.Migrations
{
    public partial class create_article_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Article",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Article",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Article");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Article",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
