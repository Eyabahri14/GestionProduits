using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Cin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Cin);
                });

            migrationBuilder.CreateTable(
                name: "MyCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateProd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryFK = table.Column<int>(type: "int", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Herbs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_StreetAddress = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_MyCategories_CategoryFK",
                        column: x => x.CategoryFK,
                        principalTable: "MyCategories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                    table.ForeignKey(
                        name: "FK_Providers_MyCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MyCategories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Factures",
                columns: table => new
                {
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductFK = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factures", x => new { x.ClientFK, x.ProductFK, x.DateAchat });
                    table.ForeignKey(
                        name: "FK_Factures_Clients_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "Clients",
                        principalColumn: "Cin",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Factures_Products_ProductFK",
                        column: x => x.ProductFK,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyProvidings",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    ProvidersProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyProvidings", x => new { x.ProductsProductId, x.ProvidersProviderId });
                    table.ForeignKey(
                        name: "FK_MyProvidings_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyProvidings_Providers_ProvidersProviderId",
                        column: x => x.ProvidersProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factures_ProductFK",
                table: "Factures",
                column: "ProductFK");

            migrationBuilder.CreateIndex(
                name: "IX_MyProvidings_ProvidersProviderId",
                table: "MyProvidings",
                column: "ProvidersProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryFK",
                table: "Products",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CategoryId",
                table: "Providers",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factures");

            migrationBuilder.DropTable(
                name: "MyProvidings");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "MyCategories");
        }
    }
}
