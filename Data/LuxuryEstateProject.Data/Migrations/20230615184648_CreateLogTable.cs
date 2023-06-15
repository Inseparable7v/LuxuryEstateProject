using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LuxuryEstateProject.Data.Migrations
{
    public partial class CreateLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Log_19118027",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn_19118027 = table.Column<DateTime>(nullable: false),
                    ModifiedOn_19118027 = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OperationType = table.Column<string>(nullable: true),
                    TimeOfTheChange = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_19118027", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_19118027_IsDeleted",
                table: "Log_19118027",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log_19118027");
        }
    }
}
