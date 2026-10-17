using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DhlLesson09Bai2TuLam.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BANNER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    Prioty = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Image = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANNER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BLOG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "CAST(GETDATE() AS date)"),
                    Image = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLOG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "CAST(GETDATE() AS date)"),
                    Image = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    salePrice = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Status = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "CAST(GETDATE() AS date)"),
                    Image = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUCT_CATEGORY_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CATEGORY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BANNER",
                columns: new[] { "Id", "Description", "Image", "Name", "Prioty", "Status" },
                values: new object[,]
                {
                    { 1, "Giảm giá lên đến 50% toàn bộ sản phẩm công nghệ", "banner1.jpg", "Khuyến mãi Tết 2026", 1, (byte)1 },
                    { 2, "Đón đầu xu hướng công nghệ tương lai", "banner2.jpg", "Ra mắt sản phẩm mới", 2, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "BLOG",
                columns: new[] { "Id", "CreatedDate", "Description", "Image", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bài viết phân tích chuyên sâu về camera và chip A17 Pro", "blog1.jpg", "Đánh giá chi tiết hiệu năng iPhone 15 Pro Max", (byte)1 },
                    { 2, new DateTime(2026, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gợi ý các dòng laptop mỏng nhẹ, pin trâu phù hợp sinh viên và dân văn phòng", "blog2.jpg", "Top 5 laptop văn phòng đáng mua nhất năm 2026", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "CATEGORY",
                columns: new[] { "Id", "CreatedDate", "Description", "Image", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Các thiết bị di động thông minh", "cat1.jpg", "Điện thoại & Tablet", (byte)1 },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Máy tính xách tay và máy tính để bàn", "cat2.jpg", "Laptop & Máy tính", (byte)1 },
                    { 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tai nghe, bàn phím, chuột, sạc cáp", "cat3.jpg", "Phụ kiện công nghệ", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "PRODUCT",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Image", "Name", "Price", "Status", "salePrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thiết kế titan cao cấp, chip A17 Pro mạnh mẽ", "iphone15.jpg", "iPhone 15 Pro Max 256GB", 29990000.0, (byte)1, 28490000.0 },
                    { 2, 1, new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trí tuệ nhân tạo Galaxy AI đỉnh cao", "s24.jpg", "Samsung Galaxy S24 Ultra", 31990000.0, (byte)1, 29990000.0 },
                    { 3, 2, new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Màn hình Liquid Retina 15.3 inch, chip M3 nhanh vượt trội", "macbookm3.jpg", "MacBook Air M3 15 inch", 32990000.0, (byte)1, 30990000.0 },
                    { 4, 3, new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chống ồn chủ động gấp 2 lần thế hệ trước", "airpods.jpg", "Tai nghe AirPods Pro 2 MagSafe", 5990000.0, (byte)1, 5490000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BANNER_Name",
                table: "BANNER",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BLOG_Name",
                table: "BLOG",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_Name",
                table: "CATEGORY",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_CategoryId",
                table: "PRODUCT",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_Name",
                table: "PRODUCT",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANNER");

            migrationBuilder.DropTable(
                name: "BLOG");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "CATEGORY");
        }
    }
}
