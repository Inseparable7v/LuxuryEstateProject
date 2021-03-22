using Microsoft.EntityFrameworkCore.Migrations;

namespace LuxuryEstateProject.Data.Migrations
{
    public partial class AgentAddedToCommentDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RealEstateProperties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AgentId",
                table: "Comment",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Agents_AgentId",
                table: "Comment",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Agents_AgentId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_AgentId",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RealEstateProperties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
