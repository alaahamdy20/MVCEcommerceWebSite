using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCEcommerceWebSite.Data.Migrations
{
    public partial class dbv9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colors_ColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ColorsProduct",
                columns: table => new
                {
                    ColorsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorsProduct", x => new { x.ColorsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ColorsProduct_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorsProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorsProduct_ProductsId",
                table: "ColorsProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorsProduct");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colors_ColorId",
                table: "Products",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
