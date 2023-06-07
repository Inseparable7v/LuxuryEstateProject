using Microsoft.EntityFrameworkCore.Migrations;

namespace LuxuryEstateProject.Data.Migrations
{
    public partial class RenameColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Settings",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Settings",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "RealEstateProperties",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "RealEstateProperties",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Images",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Images",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Districts",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Districts",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Countries",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Countries",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Comment",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Comment",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Cities",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Cities",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "BlogImage",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "BlogImage",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Blog",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Blog",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Amenities",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Amenities",
                newName: "CreatedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Agents",
                newName: "ModifiedOn_19118027");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Agents",
                newName: "CreatedOn_19118027");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "Settings",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "Settings",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "RealEstateProperties",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "RealEstateProperties",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "Images",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "Images",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "Districts",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "Districts",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "Countries",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "Countries",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "Comment",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "Comment",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "Cities",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "Cities",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "BlogImage",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "BlogImage",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "Blog",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "Blog",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "Amenities",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "Amenities",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn_19118027",
                table: "Agents",
                newName: "ModifiedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOn_19118027",
                table: "Agents",
                newName: "CreatedOn");
        }
    }
}
