using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReboteqTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TotalPriceAfterDiscount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Grocery" },
                    { 2, "Grocery" },
                    { 3, "Toys" },
                    { 4, "Kids" },
                    { 5, "Shoes" },
                    { 6, "Automotive" },
                    { 7, "Tools" },
                    { 8, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "Discount" },
                values: new object[,]
                {
                    { 1, "COUPON-T0PI9V", 27.20511555840400m },
                    { 2, "COUPON-ITSOP5", 24.050513738076900m },
                    { 3, "COUPON-GC2592", 7.1857321456225550m },
                    { 4, "COUPON-DLKM69", 5.2952985863887775m },
                    { 5, "COUPON-8VN2D8", 11.075643775710925m },
                    { 6, "COUPON-POHM3B", 24.402851942453100m },
                    { 7, "COUPON-3L04H2", 8.458233111650075m },
                    { 8, "COUPON-W9ZJG9", 20.301118438119025m },
                    { 9, "COUPON-RQ9JRM", 5.291366909874875m },
                    { 10, "COUPON-5GQURI", 17.301009691701925m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Photo", "Price" },
                values: new object[,]
                {
                    { 1, 4, "Rustic Granite Mouse", "https://picsum.photos/640/480/?image=256", 704.36m },
                    { 2, 4, "Incredible Frozen Car", "https://picsum.photos/640/480/?image=81", 208.49m },
                    { 3, 5, "Licensed Concrete Mouse", "https://picsum.photos/640/480/?image=516", 609.24m },
                    { 4, 3, "Incredible Metal Hat", "https://picsum.photos/640/480/?image=1074", 957.91m },
                    { 5, 1, "Incredible Soft Gloves", "https://picsum.photos/640/480/?image=607", 355.38m },
                    { 6, 1, "Fantastic Fresh Shoes", "https://picsum.photos/640/480/?image=42", 596.37m },
                    { 7, 7, "Awesome Rubber Car", "https://picsum.photos/640/480/?image=1046", 51.16m },
                    { 8, 1, "Gorgeous Rubber Pants", "https://picsum.photos/640/480/?image=1075", 155.44m },
                    { 9, 8, "Generic Plastic Hat", "https://picsum.photos/640/480/?image=460", 248.28m },
                    { 10, 5, "Incredible Metal Soap", "https://picsum.photos/640/480/?image=1053", 929.37m },
                    { 11, 7, "Practical Plastic Tuna", "https://picsum.photos/640/480/?image=632", 615.93m },
                    { 12, 4, "Small Rubber Keyboard", "https://picsum.photos/640/480/?image=891", 828.65m },
                    { 13, 8, "Awesome Concrete Salad", "https://picsum.photos/640/480/?image=795", 139.97m },
                    { 14, 6, "Rustic Soft Soap", "https://picsum.photos/640/480/?image=409", 907.98m },
                    { 15, 2, "Incredible Cotton Salad", "https://picsum.photos/640/480/?image=11", 591.24m },
                    { 16, 3, "Fantastic Concrete Chicken", "https://picsum.photos/640/480/?image=522", 839.29m },
                    { 17, 6, "Refined Plastic Bike", "https://picsum.photos/640/480/?image=348", 890.73m },
                    { 18, 3, "Refined Wooden Table", "https://picsum.photos/640/480/?image=374", 855.81m },
                    { 19, 1, "Handmade Cotton Table", "https://picsum.photos/640/480/?image=34", 861.94m },
                    { 20, 7, "Practical Granite Bacon", "https://picsum.photos/640/480/?image=391", 444.11m },
                    { 21, 2, "Handcrafted Soft Towels", "https://picsum.photos/640/480/?image=825", 896.49m },
                    { 22, 8, "Handmade Cotton Mouse", "https://picsum.photos/640/480/?image=754", 936.61m },
                    { 23, 8, "Sleek Frozen Chair", "https://picsum.photos/640/480/?image=923", 202.24m },
                    { 24, 6, "Fantastic Rubber Bacon", "https://picsum.photos/640/480/?image=621", 794.60m },
                    { 25, 4, "Fantastic Cotton Chicken", "https://picsum.photos/640/480/?image=213", 535.25m },
                    { 26, 8, "Licensed Granite Gloves", "https://picsum.photos/640/480/?image=710", 896.56m },
                    { 27, 3, "Unbranded Metal Ball", "https://picsum.photos/640/480/?image=903", 260.92m },
                    { 28, 6, "Awesome Granite Pizza", "https://picsum.photos/640/480/?image=61", 347.79m },
                    { 29, 4, "Small Soft Keyboard", "https://picsum.photos/640/480/?image=225", 26.20m },
                    { 30, 4, "Awesome Metal Shirt", "https://picsum.photos/640/480/?image=1000", 476.99m },
                    { 31, 1, "Gorgeous Granite Pizza", "https://picsum.photos/640/480/?image=342", 504.71m },
                    { 32, 8, "Small Cotton Car", "https://picsum.photos/640/480/?image=32", 362.21m },
                    { 33, 8, "Rustic Cotton Towels", "https://picsum.photos/640/480/?image=424", 393.65m },
                    { 34, 5, "Rustic Soft Tuna", "https://picsum.photos/640/480/?image=268", 593.50m },
                    { 35, 6, "Rustic Wooden Hat", "https://picsum.photos/640/480/?image=555", 722.53m },
                    { 36, 5, "Small Metal Mouse", "https://picsum.photos/640/480/?image=465", 265.51m },
                    { 37, 3, "Intelligent Frozen Towels", "https://picsum.photos/640/480/?image=3", 627.67m },
                    { 38, 2, "Refined Rubber Computer", "https://picsum.photos/640/480/?image=582", 98.04m },
                    { 39, 4, "Fantastic Metal Soap", "https://picsum.photos/640/480/?image=299", 121.91m },
                    { 40, 8, "Ergonomic Soft Keyboard", "https://picsum.photos/640/480/?image=954", 524.24m },
                    { 41, 8, "Incredible Granite Soap", "https://picsum.photos/640/480/?image=120", 715.00m },
                    { 42, 4, "Small Steel Chair", "https://picsum.photos/640/480/?image=626", 253.61m },
                    { 43, 8, "Handcrafted Steel Sausages", "https://picsum.photos/640/480/?image=510", 116.38m },
                    { 44, 3, "Rustic Soft Bike", "https://picsum.photos/640/480/?image=808", 972.50m },
                    { 45, 5, "Incredible Frozen Tuna", "https://picsum.photos/640/480/?image=1001", 201.48m },
                    { 46, 5, "Awesome Soft Fish", "https://picsum.photos/640/480/?image=720", 481.58m },
                    { 47, 2, "Refined Soft Fish", "https://picsum.photos/640/480/?image=620", 899.71m },
                    { 48, 6, "Practical Wooden Towels", "https://picsum.photos/640/480/?image=1066", 198.01m },
                    { 49, 7, "Unbranded Concrete Gloves", "https://picsum.photos/640/480/?image=205", 58.02m },
                    { 50, 6, "Awesome Rubber Ball", "https://picsum.photos/640/480/?image=420", 572.60m },
                    { 51, 7, "Handcrafted Plastic Bike", "https://picsum.photos/640/480/?image=132", 808.76m },
                    { 52, 8, "Sleek Cotton Table", "https://picsum.photos/640/480/?image=1015", 828.89m },
                    { 53, 5, "Practical Frozen Soap", "https://picsum.photos/640/480/?image=451", 163.52m },
                    { 54, 4, "Unbranded Granite Gloves", "https://picsum.photos/640/480/?image=323", 863.16m },
                    { 55, 6, "Incredible Concrete Ball", "https://picsum.photos/640/480/?image=445", 150.51m },
                    { 56, 1, "Handcrafted Fresh Sausages", "https://picsum.photos/640/480/?image=58", 261.41m },
                    { 57, 5, "Ergonomic Metal Chair", "https://picsum.photos/640/480/?image=899", 749.83m },
                    { 58, 6, "Unbranded Plastic Towels", "https://picsum.photos/640/480/?image=957", 519.95m },
                    { 59, 8, "Fantastic Soft Shoes", "https://picsum.photos/640/480/?image=588", 692.04m },
                    { 60, 4, "Rustic Wooden Keyboard", "https://picsum.photos/640/480/?image=512", 292.80m },
                    { 61, 7, "Ergonomic Concrete Table", "https://picsum.photos/640/480/?image=1052", 335.63m },
                    { 62, 3, "Ergonomic Plastic Bike", "https://picsum.photos/640/480/?image=468", 744.52m },
                    { 63, 7, "Incredible Plastic Chair", "https://picsum.photos/640/480/?image=772", 952.45m },
                    { 64, 5, "Ergonomic Granite Gloves", "https://picsum.photos/640/480/?image=716", 906.49m },
                    { 65, 7, "Tasty Granite Sausages", "https://picsum.photos/640/480/?image=1011", 714.82m },
                    { 66, 4, "Fantastic Soft Mouse", "https://picsum.photos/640/480/?image=311", 670.91m },
                    { 67, 6, "Gorgeous Fresh Pizza", "https://picsum.photos/640/480/?image=919", 54.10m },
                    { 68, 1, "Practical Plastic Keyboard", "https://picsum.photos/640/480/?image=331", 949.87m },
                    { 69, 8, "Fantastic Wooden Tuna", "https://picsum.photos/640/480/?image=181", 989.36m },
                    { 70, 4, "Refined Frozen Table", "https://picsum.photos/640/480/?image=432", 756.68m },
                    { 71, 4, "Small Concrete Towels", "https://picsum.photos/640/480/?image=756", 182.76m },
                    { 72, 5, "Unbranded Plastic Computer", "https://picsum.photos/640/480/?image=220", 529.40m },
                    { 73, 8, "Handcrafted Plastic Ball", "https://picsum.photos/640/480/?image=259", 459.93m },
                    { 74, 5, "Practical Rubber Shoes", "https://picsum.photos/640/480/?image=442", 348.24m },
                    { 75, 7, "Generic Metal Cheese", "https://picsum.photos/640/480/?image=989", 245.27m },
                    { 76, 5, "Awesome Soft Pants", "https://picsum.photos/640/480/?image=1060", 521.48m },
                    { 77, 3, "Licensed Fresh Chips", "https://picsum.photos/640/480/?image=865", 577.85m },
                    { 78, 6, "Gorgeous Rubber Ball", "https://picsum.photos/640/480/?image=651", 215.37m },
                    { 79, 4, "Gorgeous Wooden Towels", "https://picsum.photos/640/480/?image=641", 29.09m },
                    { 80, 1, "Tasty Cotton Soap", "https://picsum.photos/640/480/?image=469", 96.84m },
                    { 81, 1, "Intelligent Soft Gloves", "https://picsum.photos/640/480/?image=575", 838.03m },
                    { 82, 4, "Gorgeous Steel Shoes", "https://picsum.photos/640/480/?image=1013", 398.62m },
                    { 83, 8, "Fantastic Rubber Salad", "https://picsum.photos/640/480/?image=600", 401.35m },
                    { 84, 5, "Sleek Cotton Computer", "https://picsum.photos/640/480/?image=188", 582.18m },
                    { 85, 2, "Small Wooden Pants", "https://picsum.photos/640/480/?image=306", 443.10m },
                    { 86, 7, "Sleek Granite Table", "https://picsum.photos/640/480/?image=712", 331.50m },
                    { 87, 1, "Unbranded Frozen Sausages", "https://picsum.photos/640/480/?image=963", 672.66m },
                    { 88, 3, "Practical Metal Soap", "https://picsum.photos/640/480/?image=202", 219.74m },
                    { 89, 5, "Awesome Steel Ball", "https://picsum.photos/640/480/?image=749", 918.19m },
                    { 90, 7, "Gorgeous Fresh Chips", "https://picsum.photos/640/480/?image=910", 503.63m },
                    { 91, 1, "Rustic Wooden Sausages", "https://picsum.photos/640/480/?image=477", 132.26m },
                    { 92, 5, "Unbranded Steel Chicken", "https://picsum.photos/640/480/?image=1082", 471.15m },
                    { 93, 7, "Handcrafted Soft Chicken", "https://picsum.photos/640/480/?image=46", 879.43m },
                    { 94, 7, "Unbranded Granite Chicken", "https://picsum.photos/640/480/?image=296", 595.30m },
                    { 95, 2, "Sleek Plastic Pants", "https://picsum.photos/640/480/?image=489", 230.57m },
                    { 96, 5, "Rustic Fresh Bacon", "https://picsum.photos/640/480/?image=294", 151.97m },
                    { 97, 4, "Intelligent Cotton Pizza", "https://picsum.photos/640/480/?image=336", 634.28m },
                    { 98, 4, "Handmade Granite Soap", "https://picsum.photos/640/480/?image=512", 602.29m },
                    { 99, 3, "Licensed Fresh Mouse", "https://picsum.photos/640/480/?image=16", 523.55m },
                    { 100, 7, "Tasty Fresh Car", "https://picsum.photos/640/480/?image=341", 649.34m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CouponId",
                table: "Orders",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
