using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class Create_Table_Category_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories_1",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories_1", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "ProductNew_",
                columns: table => new
                {
                    ProductNewID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductNewName = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNew_", x => x.ProductNewID);
                    table.ForeignKey(
                        name: "FK_ProductNew__Categories_1_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories_1",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductNew__CategoryID",
                table: "ProductNew_",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductNew_");

            migrationBuilder.DropTable(
                name: "Categories_1");
        }
    }
}
