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
                values: new object[,]
                {
                    { 1, "Product-001", new DateTimeOffset(new DateTime(2021, 6, 6, 18, 47, 31, 513, DateTimeKind.Unspecified).AddTicks(1426), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "Product 1", 10.25m },
                    { 2, "Product-002", new DateTimeOffset(new DateTime(2021, 6, 6, 18, 47, 31, 513, DateTimeKind.Unspecified).AddTicks(2385), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "Product 2", 45m },
                    { 3, "Product-003", new DateTimeOffset(new DateTime(2021, 6, 6, 18, 47, 31, 513, DateTimeKind.Unspecified).AddTicks(2401), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "Product 3", 9.25m },
                    { 4, "Product-004", new DateTimeOffset(new DateTime(2021, 6, 6, 18, 47, 31, 513, DateTimeKind.Unspecified).AddTicks(2402), new TimeSpan(0, 0, 0, 0, 0)), null, false, null, "Product 4", 3.99m }
                });
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
