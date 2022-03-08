using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCEcommerceWebSite.Data.Migrations
{
    public partial class addtaable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "SellerUsers",
                columns: table => new
                {
                    userid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    productid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerUsers", x => new { x.userid, x.productid });
                    table.ForeignKey(
                        name: "FK_SellerUsers_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerUsers_Products_productid",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellerUsers_productid",
                table: "SellerUsers",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SellerUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
