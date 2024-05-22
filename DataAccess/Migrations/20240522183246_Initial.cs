using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    HalfDozenPrice = table.Column<double>(type: "float", nullable: false),
                    DozenPrice = table.Column<double>(type: "float", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Non-Alcoholic Beverages" },
                    { 2, 2, "Wine" },
                    { 3, 3, "Snacks" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Coca Cola" },
                    { 2, "The Casella Family" },
                    { 3, "Trinchero Family Estates" },
                    { 4, "Frito Lay" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "DozenPrice", "HalfDozenPrice", "ImageUrl", "ListPrice", "ManufacturerId", "Name", "Size", "UPC", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "The primary taste of Coca-Cola is thought to come from vanilla and cinnamon, with trace amounts of essential oils, and spices such as nutmeg.", 0.98999999999999999, 1.24, "/images/products/Coke.jpg", 1.99, 1, "Coca Cola Classic", "33cl", "4894034", 1.49 },
                    { 2, 2, "<p>The Yellow Tail Shiraz has a deep red color with bright purple hues, characteristic of fine young wines. It displays impressive <strong>spice, licorice, and black currant aromas</strong>. The palate is perfectly balanced with soft tannins and fine French Oak, further complemented by ripe fruit flavors.</p>", 6.9900000000000002, 7.9900000000000002, "/images/products/YellowTail.png", 9.9900000000000002, 2, "Yellow Tail Shiraz", "750 ml", "031259008943", 8.9900000000000002 },
                    { 3, 2, "Menage a Trois California Red Blend exposes the fresh, ripe, jam-like fruit that is the calling card of California wine. Forward, spicy and soft, this delicious dalliance makes the perfect accompaniment for grilled meats or chicken.", 9.9900000000000002, 10.75, "/images/products/menage.jpg", 12.99, 3, "Menage a Trois Merlot", "750 ml", "099988071096", 11.49 },
                    { 4, 3, "The chip that packs a flavorful punch with the classic crunch. Boldly seasoned with three cheeses, tomatoes, onions, and a savory blend of spices. Indulge yourself or share with large gatherings", 0.68999999999999995, 1.05, "/images/products/doritos.jpg", 1.99, 4, "Doritos", "175 grams", "028400443753", 1.49 },
                    { 5, 3, "The fun, crunchy snack that is made with real cheese. Packed with flavor that satisfies. Always a crowd favorite.", 0.68999999999999995, 1.05, "/images/products/cheetos.jpg", 1.99, 4, "Cheetos", "200 grams", "028400443661", 1.49 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
