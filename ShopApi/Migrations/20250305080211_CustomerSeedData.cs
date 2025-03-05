using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopApi.Migrations
{
    /// <inheritdoc />
    public partial class CustomerSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "TCKN" },
                values: new object[,]
                {
                    { new Guid("a7f3a7f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), "tomakintomakin05@gmail.com", "Ömer", "Tomakin", 231 },
                    { new Guid("b8f3b8f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), "ali.yilmaz@example.com", "Ali", "Yılmaz", 234 },
                    { new Guid("c9f4c9f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), "ayse.kara@example.com", "Ayşe", "Kara", 235 },
                    { new Guid("d1f5d1f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), "murat.demir@example.com", "Murat", "Demir", 236 },
                    { new Guid("e2f6e2f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), "fatma.ozturk@example.com", "Fatma", "Öztürk", 237 },
                    { new Guid("f3f7f3f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), "mehmet.celik@example.com", "Mehmet", "Çelik", 238 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a7f3a7f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b8f3b8f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c9f4c9f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d1f5d1f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e2f6e2f6-1e1f-5e0e-f1f1-2dbdd28eea9f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f3f7f3f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"));
        }
    }
}
