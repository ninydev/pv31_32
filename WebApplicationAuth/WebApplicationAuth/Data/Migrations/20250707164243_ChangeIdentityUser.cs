using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAuth.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelegramId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelegramUserName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelegramId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TelegramUserName",
                table: "AspNetUsers");
        }
    }
}
