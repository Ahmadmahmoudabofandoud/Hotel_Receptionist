using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelSystem.Migrations
{
    /// <inheritdoc />
    public partial class navigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Guestts",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Guestts_RoomId",
                table: "Guestts",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guestts_Rooms_RoomId",
                table: "Guestts",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guestts_Rooms_RoomId",
                table: "Guestts");

            migrationBuilder.DropIndex(
                name: "IX_Guestts_RoomId",
                table: "Guestts");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Guestts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOutDate",
                table: "Guestts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
