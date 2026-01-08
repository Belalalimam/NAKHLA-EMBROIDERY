using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class updatetheinsertdata1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "UserOTPs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "UserOTPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "UserOTPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "UserOTPs");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "UserOTPs");

            migrationBuilder.DropColumn(
                name: "OTP",
                table: "UserOTPs");

            
        }
    }
}
