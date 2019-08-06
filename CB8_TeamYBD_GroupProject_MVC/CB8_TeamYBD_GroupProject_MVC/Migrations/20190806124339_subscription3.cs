using Microsoft.EntityFrameworkCore.Migrations;

namespace CB8_TeamYBD_GroupProject_MVC.Migrations
{
    public partial class subscription3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionListings_AspNetUsers_UserId",
                table: "SubscriptionListings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SubscriptionListings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionListings_AspNetUsers_UserId",
                table: "SubscriptionListings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionListings_AspNetUsers_UserId",
                table: "SubscriptionListings");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SubscriptionListings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionListings_AspNetUsers_UserId",
                table: "SubscriptionListings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
