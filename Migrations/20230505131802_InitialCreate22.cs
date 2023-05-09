using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techTask2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Inspectors_InspectorId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_InspectorId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "InspectorId",
                table: "Applications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InspectorId",
                table: "Applications",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_InspectorId",
                table: "Applications",
                column: "InspectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Inspectors_InspectorId",
                table: "Applications",
                column: "InspectorId",
                principalTable: "Inspectors",
                principalColumn: "Id");
        }
    }
}
