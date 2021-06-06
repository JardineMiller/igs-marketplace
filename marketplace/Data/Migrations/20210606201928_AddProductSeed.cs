using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace marketplace.Migrations
{
    public partial class AddProductSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Price" },
                values: new object[] { 1, "001", new DateTimeOffset(new DateTime(2021, 6, 6, 20, 19, 28, 223, DateTimeKind.Unspecified).AddTicks(2034), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "Lavender heart", 9.25m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Price" },
                values: new object[] { 2, "002", new DateTimeOffset(new DateTime(2021, 6, 6, 20, 19, 28, 223, DateTimeKind.Unspecified).AddTicks(2903), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "Personalised cufflinks", 45m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Code", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Price" },
                values: new object[] { 3, "003", new DateTimeOffset(new DateTime(2021, 6, 6, 20, 19, 28, 223, DateTimeKind.Unspecified).AddTicks(2917), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "Kids T-shirt", 19.95m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
