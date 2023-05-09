using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techTask2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Inspectors_InspectorId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "InspectorFullName",
                table: "Applications");

            migrationBuilder.AlterColumn<int>(
                name: "InspectorId",
                table: "Applications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Inspectors_InspectorId",
                table: "Applications",
                column: "InspectorId",
                principalTable: "Inspectors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Inspectors_InspectorId",
                table: "Applications");

            migrationBuilder.AlterColumn<int>(
                name: "InspectorId",
                table: "Applications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspectorFullName",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Inspectors_InspectorId",
                table: "Applications",
                column: "InspectorId",
                principalTable: "Inspectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
