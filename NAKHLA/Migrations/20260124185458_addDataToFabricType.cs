using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class addDataToFabricType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into FabricTypes (Name, Slug) values ('Bouclé - Tweed', 'boucle-tweed');insert into FabricTypes (Name, Slug) values ('Fine Suit', 'fine-suit');insert into FabricTypes (Name, Slug) values ('Laces & Embroidery', 'laces-embroidery');insert into FabricTypes (Name, Slug) values ('Jacquard', 'jacquard');insert into FabricTypes (Name, Slug) values ('Plain', 'plain');insert into FabricTypes (Name, Slug) values ('Print', 'print');insert into FabricTypes (Name, Slug) values ('Shirting', 'shirting');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE FabricType");
        }
    }
}
