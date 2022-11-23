using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todo.Migrations
{
    public partial class category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CId",
                table: "todoTask",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CId);
                    table.ForeignKey(
                        name: "FK_Category_Category_CategoryCId",
                        column: x => x.CategoryCId,
                        principalTable: "Category",
                        principalColumn: "CId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_todoTask_CId",
                table: "todoTask",
                column: "CId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryCId",
                table: "Category",
                column: "CategoryCId");

            migrationBuilder.AddForeignKey(
                name: "FK_todoTask_Category_CId",
                table: "todoTask",
                column: "CId",
                principalTable: "Category",
                principalColumn: "CId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todoTask_Category_CId",
                table: "todoTask");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_todoTask_CId",
                table: "todoTask");

            migrationBuilder.DropColumn(
                name: "CId",
                table: "todoTask");
        }
    }
}
