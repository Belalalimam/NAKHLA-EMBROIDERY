using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class addDataToProductTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into ProductTags (Name, Slug) values ('Brocade', 'brocade-fabrics');\r\ninsert into ProductTags (Name, Slug) values ('Jacquard', 'jacquard-fabrics');\r\ninsert into ProductTags (Name, Slug) values ('Velvet', 'velvet-fabrics');\r\ninsert into ProductTags (Name, Slug) values ('Lace', 'lace-fabrics');\r\ninsert into ProductTags (Name, Slug) values ('Print', 'print-fabrics');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE Tabel ProductTags");
        }
    }
}
