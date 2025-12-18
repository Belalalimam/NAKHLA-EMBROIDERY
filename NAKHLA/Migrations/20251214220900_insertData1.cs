using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class insertData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Brands (Name, Description, Status) values ('Tazz', null, 1);\r\ninsert into Brands (Name, Description, Status) values ('Aivee', null, 1);\r\ninsert into Brands (Name, Description, Status) values ('Wordtune', null, 1);\r\ninsert into Brands (Name, Description, Status) values ('Browseblab', null, 1);\r\ninsert into Brands (Name, Description, Status) values ('Camido', null, 1);\r\ninsert into Brands (Name, Description, Status) values ('Centizu', null, 0);\r\ninsert into Brands (Name, Description, Status) values ('Jaxbean', null, 0);\r\ninsert into Brands (Name, Description, Status) values ('Kwinu', null, 0);\r\ninsert into Brands (Name, Description, Status) values ('Tanoodle', null, 0);\r\ninsert into Brands (Name, Description, Status) values ('Roombo', null, 0);\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Brands");
        }
    }
}
