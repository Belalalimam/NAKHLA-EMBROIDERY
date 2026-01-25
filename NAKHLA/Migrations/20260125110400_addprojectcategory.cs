using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class addprojectcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into ProjectCategories (Name, Slug) values ('Shirt', 'shirt');\r\ninsert into ProjectCategories (Name, Slug) values ('Underwear', 'underwear');\r\ninsert into ProjectCategories (Name, Slug) values ('Dress', 'dress');\r\ninsert into ProjectCategories (Name, Slug) values ('Coat', 'coat');\r\ninsert into ProjectCategories (Name, Slug) values ('Skirt', 'skirt');\r\ninsert into ProjectCategories (Name, Slug) values ('Pants', 'pants');\r\ninsert into ProjectCategories (Name, Slug) values ('Wedding Dress', 'wedding-dress');\r\ninsert into ProjectCategories (Name, Slug) values ('Suit', 'suit');\r\ninsert into ProjectCategories (Name, Slug) values ('Light Coat', 'light-coat');\r\ninsert into ProjectCategories (Name, Slug) values ('Party Dress', 'party-dress');\r\ninsert into ProjectCategories (Name, Slug) values ('Formal Wear', 'formal-wear');\r\ninsert into ProjectCategories (Name, Slug) values ('Jacket', 'jacket');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE Table ProjectCategories");
        }
    }
}
