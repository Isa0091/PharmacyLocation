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
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescriptionName = table.Column<string>(name: "Description_Name", type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DescriptionDescription = table.Column<string>(name: "Description_Description", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LocationLatitude = table.Column<double>(name: "Location_Latitude", type: "float", nullable: false),
                    LocationLongitude = table.Column<double>(name: "Location_Longitude", type: "float", nullable: false),
                    LocationPresicion = table.Column<double>(name: "Location_Presicion", type: "float", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
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
                    DescriptionName = table.Column<string>(name: "Description_Name", type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DescriptionDescription = table.Column<string>(name: "Description_Description", type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                name: "IX_PharmacyProducts_IdPharmacy",
                table: "PharmacyProducts",
                column: "IdPharmacy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteUserProducts");

            migrationBuilder.DropTable(
                name: "PharmacyProducts");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
