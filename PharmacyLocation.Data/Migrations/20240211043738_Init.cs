using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyLocation.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Location_Latitude = table.Column<double>(type: "float", nullable: false),
                    Location_Longitude = table.Column<double>(type: "float", nullable: false),
                    Location_Presicion = table.Column<double>(type: "float", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsOpenAllHours = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacySchedule",
                columns: table => new
                {
                    Day = table.Column<int>(type: "int", nullable: false),
                    PharmacyId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacySchedule", x => new { x.Day, x.PharmacyId });
                    table.ForeignKey(
                        name: "FK_PharmacySchedule_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteUserProducts",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteUserProducts", x => new { x.ProductId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavoriteUserProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyProducts",
                columns: table => new
                {
                    IdProduct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdPharmacy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyProducts", x => new { x.IdProduct, x.IdPharmacy });
                    table.ForeignKey(
                        name: "FK_PharmacyProducts_Pharmacies_IdPharmacy",
                        column: x => x.IdPharmacy,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PharmacyProducts_Products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductId",
                table: "CategoryProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyProducts_IdPharmacy",
                table: "PharmacyProducts",
                column: "IdPharmacy");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacySchedule_PharmacyId",
                table: "PharmacySchedule",
                column: "PharmacyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "FavoriteUserProducts");

            migrationBuilder.DropTable(
                name: "PharmacyProducts");

            migrationBuilder.DropTable(
                name: "PharmacySchedule");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Pharmacies");
        }
    }
}
