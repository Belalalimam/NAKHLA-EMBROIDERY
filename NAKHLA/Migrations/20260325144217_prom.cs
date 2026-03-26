using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class prom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Promotions (Code,Name,CreatedAt, IsValid,DiscountValue, StartDate, EndDate) values ('YYY80', 'Belal', '1/1/1990', 0, 2.5, '1/1/1990', '5/1/1990');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE Table Promo");
        }
    }
}
