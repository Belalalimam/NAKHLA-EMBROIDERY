using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAKHLA.Migrations
{
    /// <inheritdoc />
    public partial class insertData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Categorise (Name, Description, Status) values ('Home', 'Phasellus sit amet erat. Nulla tempus. Vivamus in felis eu sapien cursus vestibulum.', 1);\r\ninsert into Categorise (Name, Description, Status) values ('Computers', 'Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla. Nunc purus.', 1);\r\ninsert into Categorise (Name, Description, Status) values ('Kitchen', 'Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus. Duis at velit eu est congue elementum.', 1);\r\ninsert into Categorise (Name, Description, Status) values ('Clothing - Dresses', 'Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo. In blandit ultrices enim. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.', 1);\r\ninsert into Categorise (Name, Description, Status) values ('Food - Canned Goods', 'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.', 1);\r\ninsert into Categorise (Name, Description, Status) values ('Food - Beverages', 'Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.', 1);\r\ninsert into Categorise (Name, Description, Status) values ('Travel', 'Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.', 1);\r\ninsert into Categorise (Name, Description, Status) values ('Food - Meat', 'Sed ante. Vivamus tortor. Duis mattis egestas metus.', 1);\r\ninsert into Categorise (Name, Description, Status) values ('Garden', 'Duis consequat dui nec nisi volutpat eleifend. Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus.', 1);\r\ninsert into Categorise (Name, Description, Status) values ('Accessories', 'Sed ante. Vivamus tortor. Duis mattis egestas metus.', 1);\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Categorise");
        }
    }
}
