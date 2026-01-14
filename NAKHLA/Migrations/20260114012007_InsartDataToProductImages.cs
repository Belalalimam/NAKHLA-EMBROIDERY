using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class InsartDataToProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into productImages (ProductId, ImageUrl, DisplayOrder) values ('66', '7-2.jpg', 1);\r\ninsert into productImages (ProductId, ImageUrl, DisplayOrder) values ('66', '7-2.jpg', 1);\r\ninsert into productImages (ProductId, ImageUrl, DisplayOrder) values ('66', '7-2.jpg', 1);\r\ninsert into productImages (ProductId, ImageUrl, DisplayOrder) values ('66', '7-2.jpg', 1);\r\ninsert into productImages (ProductId, ImageUrl, DisplayOrder) values ('66', '7-2.jpg', 1);\r\ninsert into productImages (ProductId, ImageUrl, DisplayOrder) values ('66', '7-2.jpg', 1);\r\ninsert into productImages (ProductId, ImageUrl, DisplayOrder) values ('66', '7-2.jpg', 1);\r\ninsert into productImages (ProductId, ImageUrl, DisplayOrder) values ('66', '7-2.jpg', 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE productImages");
        }
    }
}
