using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DastYarHub.API.Migrations
{
    /// <inheritdoc />
    public partial class AddIconUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "Categories");
        }
    }
}
