using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableCartViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Carts");
        }
    }
}
