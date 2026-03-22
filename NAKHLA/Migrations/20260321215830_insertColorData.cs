using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class insertColorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Colors (Name, HexCode) values ('Black', '#000000');\r\ninsert into Colors (Name, HexCode) values ('Red', '#ff0000');\r\ninsert into Colors (Name, HexCode) values ('Yellow', '#ffff00');\r\ninsert into Colors (Name, HexCode) values ('Blue', '#0000ff');\r\ninsert into Colors (Name, HexCode) values ('White', '#ffffff');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE Table Colors");
        }
    }
}
