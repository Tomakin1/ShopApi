using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product");

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

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), "Apple" },
                    { new Guid("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), "Samsung" },
                    { new Guid("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), "Sony" },
                    { new Guid("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), "LG" },
                    { new Guid("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), "Huawei" },
                    { new Guid("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), "Xiaomi" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "TCKN" },
                values: new object[,]
                {
                    { new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), "tomakintomakin05@gmail.com", "Ömer", "Tomakin", 231 },
                    { new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), "ali.yilmaz@example.com", "Ali", "Yılmaz", 234 },
                    { new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), "ayse.kara@example.com", "Ayşe", "Kara", 235 },
                    { new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), "murat.demir@example.com", "Murat", "Demir", 236 },
                    { new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), "fatma.ozturk@example.com", "Fatma", "Öztürk", 237 },
                    { new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), "mehmet.celik@example.com", "Mehmet", "Çelik", 238 }
                });

            migrationBuilder.InsertData(
                table: "CustomerBrands",
                columns: new[] { "BrandId", "CustomerId" },
                values: new object[,]
                {
                    { new Guid("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c") },
                    { new Guid("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d") },
                    { new Guid("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e") },
                    { new Guid("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f") },
                    { new Guid("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f") },
                    { new Guid("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f") }
                });

            migrationBuilder.InsertData(
                table: "CustomerDetails",
                columns: new[] { "Id", "Address", "Age", "CustomerId", "Gender", "Job" },
                values: new object[,]
                {
                    { new Guid("b0a58b50-92ad-41ea-bcfb-b227d29d4b9d"), "İstanbul, Türkiye", 30, new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), true, "Yazılımcı" },
                    { new Guid("b3e4bb49-3810-41c6-bb69-29b017bb1f13"), "Ankara, Türkiye", 28, new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), true, "Mühendis" },
                    { new Guid("c6a5478e-68f6-442b-9be6-3bafced1dbd6"), "İzmir, Türkiye", 25, new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), false, "Öğrenci" },
                    { new Guid("d93d0776-6d0c-44b4-b7e0-15b5d3b90a58"), "Bursa, Türkiye", 35, new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), true, "Doktor" },
                    { new Guid("e476b789-02f0-431e-8f88-8b0c358b29e1"), "Antalya, Türkiye", 40, new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), false, "Avukat" },
                    { new Guid("f9b0e460-7425-4b79-a94c-6659fdcb373b"), "Eskişehir, Türkiye", 32, new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), true, "İşletmeci" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CustomerId", "Description", "Name", "Title", "price" },
                values: new object[,]
                {
                    { new Guid("a3f3a3f3-1f1f-4f1f-b1f1-8dbdd24dbd9c"), new Guid("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), "Apple's latest smartphone with a powerful A15 chip.", "iPhone 13", "Smartphone", 999 },
                    { new Guid("b4f4b4f4-2f2f-4f2f-b2f2-9dbdd25dcf9d"), new Guid("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), "Samsung's flagship phone with advanced camera features.", "Samsung Galaxy S21", "Smartphone", 899 },
                    { new Guid("c5f5c5f5-3f3f-5f3f-c3f3-0dbdd26dcf9e"), new Guid("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), "Sony's noise-canceling wireless headphones.", "Sony WH-1000XM4", "Headphones", 350 },
                    { new Guid("d6f6d6f6-4f4f-6f4f-d4f4-1dbdd27ddf9f"), new Guid("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), "LG's 55-inch OLED television with stunning picture quality.", "LG OLED TV", "Television", 1200 },
                    { new Guid("e7f7e7f7-5f5f-7f5f-e5f5-2dbdd28eea9f"), new Guid("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), "Huawei's premium laptop with a sleek design and powerful performance.", "Huawei MateBook X Pro", "Laptop", 1500 },
                    { new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), new Guid("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), "Xiaomi's fitness tracker with a full-screen AMOLED display.", "Xiaomi Mi Band 6", "Fitness Tracker", 50 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product");

            migrationBuilder.DeleteData(
                table: "CustomerBrands",
                keyColumns: new[] { "BrandId", "CustomerId" },
                keyValues: new object[] { new Guid("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"), new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c") });

            migrationBuilder.DeleteData(
                table: "CustomerBrands",
                keyColumns: new[] { "BrandId", "CustomerId" },
                keyValues: new object[] { new Guid("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"), new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d") });

            migrationBuilder.DeleteData(
                table: "CustomerBrands",
                keyColumns: new[] { "BrandId", "CustomerId" },
                keyValues: new object[] { new Guid("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"), new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e") });

            migrationBuilder.DeleteData(
                table: "CustomerBrands",
                keyColumns: new[] { "BrandId", "CustomerId" },
                keyValues: new object[] { new Guid("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"), new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f") });

            migrationBuilder.DeleteData(
                table: "CustomerBrands",
                keyColumns: new[] { "BrandId", "CustomerId" },
                keyValues: new object[] { new Guid("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"), new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f") });

            migrationBuilder.DeleteData(
                table: "CustomerBrands",
                keyColumns: new[] { "BrandId", "CustomerId" },
                keyValues: new object[] { new Guid("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"), new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f") });

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: new Guid("b0a58b50-92ad-41ea-bcfb-b227d29d4b9d"));

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: new Guid("b3e4bb49-3810-41c6-bb69-29b017bb1f13"));

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: new Guid("c6a5478e-68f6-442b-9be6-3bafced1dbd6"));

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: new Guid("d93d0776-6d0c-44b4-b7e0-15b5d3b90a58"));

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: new Guid("e476b789-02f0-431e-8f88-8b0c358b29e1"));

            migrationBuilder.DeleteData(
                table: "CustomerDetails",
                keyColumn: "Id",
                keyValue: new Guid("f9b0e460-7425-4b79-a94c-6659fdcb373b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a3f3a3f3-1f1f-4f1f-b1f1-8dbdd24dbd9c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("b4f4b4f4-2f2f-4f2f-b2f2-9dbdd25dcf9d"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c5f5c5f5-3f3f-5f3f-c3f3-0dbdd26dcf9e"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("d6f6d6f6-4f4f-6f4f-d4f4-1dbdd27ddf9f"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e7f7e7f7-5f5f-7f5f-e5f5-2dbdd28eea9f"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("a1f3a1f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("b2f3b2f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c3f4c3f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("d4f5d4f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e5f6e5f6-1e1f-5e0e-f1f1-2dbdd28eea9f"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f6f7f6f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a8f3a8f3-7a7f-4a6a-bfe7-8dbdd24dbd9c"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b9f3b9f3-8b8f-4b7b-cfe8-9dbdd25dcf9d"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c8f4c8f4-9c9f-4c8c-dfe9-0dbdd26dcf9e"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d0f5d0f5-0d0f-4d9d-e0f0-1dbdd27ddf9f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e1f6e1f6-1e1f-5e0e-f1f1-2dbdd28eea9f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f2f7f2f7-2f2f-6f1f-8f8f-3dbdd29ffb9f"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
