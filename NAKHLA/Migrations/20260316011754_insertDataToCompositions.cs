using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class insertDataToCompositions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Compositions (Name) values ('Cotton');\r\ninsert into Compositions (Name) values ('Slik');\r\ninsert into Compositions (Name) values ('Wool');\r\ninsert into Compositions (Name) values ('Polyester');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Compositions");
        }
    }
}
