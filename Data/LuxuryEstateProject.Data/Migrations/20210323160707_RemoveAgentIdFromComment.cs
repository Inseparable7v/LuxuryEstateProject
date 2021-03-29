using Microsoft.EntityFrameworkCore.Migrations;

namespace LuxuryEstateProject.Data.Migrations
{
    public partial class RemoveAgentIdFromComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
