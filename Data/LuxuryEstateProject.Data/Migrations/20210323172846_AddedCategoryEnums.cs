using Microsoft.EntityFrameworkCore.Migrations;

namespace LuxuryEstateProject.Data.Migrations
{
    public partial class AddedCategoryEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Blog",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
