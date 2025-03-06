using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopApi.Migrations
{
    /// <inheritdoc />
    public partial class BrandCustomerProductIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Index_ProductName",
                table: "Product",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "Index_CustomerLastName",
                table: "Customers",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "Index_BrandName",
                table: "Brands",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_ProductName",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "Index_CustomerLastName",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "Index_BrandName",
                table: "Brands");
        }
    }
}
