using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class insertDataToColors2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into ProductColors (ProductId, Name, Color) values (60, 'Black', '#000000');\r\ninsert into ProductColors (ProductId, Name, Color) values (61, 'Black', '#000000');\r\ninsert into ProductColors (ProductId, Name, Color) values (62, 'Black', '#000000');insert into ProductColors (ProductId, Name, Color) values (60, 'Black', '#000000');\r\ninsert into ProductColors (ProductId, Name, Color) values (61, 'Black', '#000000');\r\ninsert into ProductColors (ProductId, Name, Color) values (62, 'Black', '#000000');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE Table ProductColors");
        }
    }
}
