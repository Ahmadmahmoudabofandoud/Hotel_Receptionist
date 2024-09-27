using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSystem.Migrations
{
    /// <inheritdoc />
    public partial class addnewcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Guestts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Guestts",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNum",
                table: "Guestts",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Guestts");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Guestts");

            migrationBuilder.DropColumn(
                name: "PhoneNum",
                table: "Guestts");
        }
    }
}
