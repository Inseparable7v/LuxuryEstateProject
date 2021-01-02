namespace LuxuryEstateProject.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedFORKEYSForManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_RealEstateProperties_RealEstatePropertyId",
                table: "Amenities");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_RealEstatePropertyId",
                table: "Amenities");

            migrationBuilder.DropColumn(
                name: "RealEstatePropertyId",
                table: "Amenities");

            migrationBuilder.CreateTable(
                name: "RealEstateAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmenityId = table.Column<int>(nullable: false),
                    RealEstatePropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateAmenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstateAmenities_RealEstateProperties_RealEstatePropertyId",
                        column: x => x.RealEstatePropertyId,
                        principalTable: "RealEstateProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateAmenities_AmenityId",
                table: "RealEstateAmenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateAmenities_RealEstatePropertyId",
                table: "RealEstateAmenities",
                column: "RealEstatePropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateAmenities");

            migrationBuilder.AddColumn<int>(
                name: "RealEstatePropertyId",
                table: "Amenities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RealEstatePropertyId",
                table: "Amenities",
                column: "RealEstatePropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_RealEstateProperties_RealEstatePropertyId",
                table: "Amenities",
                column: "RealEstatePropertyId",
                principalTable: "RealEstateProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
