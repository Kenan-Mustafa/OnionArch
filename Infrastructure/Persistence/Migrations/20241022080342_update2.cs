using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 463, DateTimeKind.Local).AddTicks(9038), "Clothing & Sports" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 463, DateTimeKind.Local).AddTicks(9045), "Sports" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 463, DateTimeKind.Local).AddTicks(9050), "Music" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 463, DateTimeKind.Local).AddTicks(9060), "Music & Shoes" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 22, 12, 3, 39, 464, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 22, 12, 3, 39, 464, DateTimeKind.Local).AddTicks(1054));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 22, 12, 3, 39, 464, DateTimeKind.Local).AddTicks(1055));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 22, 12, 3, 39, 464, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 465, DateTimeKind.Local).AddTicks(8725), "Camisi velit sequi voluptatem veritatis.", "Aliquid." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 465, DateTimeKind.Local).AddTicks(8788), "Sandalye consequatur illo tempora karşıdakine.", "Quasi mıknatıslı." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 465, DateTimeKind.Local).AddTicks(8817), "Aut şafak gül odit autem.", "Vitae." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 468, DateTimeKind.Local).AddTicks(2326), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 4.77263694243710m, 5520.69m, "Intelligent Frozen Salad" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 468, DateTimeKind.Local).AddTicks(2453), 6.707391360575840m, 5635.49m, "Unbranded Concrete Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 10, 22, 12, 3, 39, 468, DateTimeKind.Local).AddTicks(2474), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 2.566598462335130m, 9992.68m, "Fantastic Concrete Chicken" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 693, DateTimeKind.Local).AddTicks(1742), "Electronics, Tools & Grocery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 693, DateTimeKind.Local).AddTicks(1757), "Computers, Electronics & Sports" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 693, DateTimeKind.Local).AddTicks(1763), "Automotive" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 693, DateTimeKind.Local).AddTicks(1768), "Grocery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 16, 49, 46, 693, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 16, 49, 46, 693, DateTimeKind.Local).AddTicks(5368));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 16, 49, 46, 693, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 17, 16, 49, 46, 693, DateTimeKind.Local).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 695, DateTimeKind.Local).AddTicks(3353), "Voluptatem makinesi commodi quae iure.", "De." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 695, DateTimeKind.Local).AddTicks(3392), "Quis türemiş ama sevindi quia.", "Ea numquam." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 695, DateTimeKind.Local).AddTicks(3417), "Aliquam et gidecekmiş inventore et.", "Bahar." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 697, DateTimeKind.Local).AddTicks(2529), "The Football Is Good For Training And Recreational Purposes", 0.7677430772354180m, 1596.44m, "Gorgeous Frozen Car" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 697, DateTimeKind.Local).AddTicks(2667), 8.669834187505370m, 2226.31m, "Fantastic Rubber Fish" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 10, 17, 16, 49, 46, 697, DateTimeKind.Local).AddTicks(2690), "The Football Is Good For Training And Recreational Purposes", 0.1530144153437780m, 7052.73m, "Generic Soft Tuna" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
