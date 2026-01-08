using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "UserOTPs");

            migrationBuilder.DropColumn(
                name: "OTPNumber",
                table: "UserOTPs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "UserOTPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OTPNumber",
                table: "UserOTPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
