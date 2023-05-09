using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techTask2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Operator_OperatorId",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operator",
                table: "Operator");

            migrationBuilder.RenameTable(
                name: "Operator",
                newName: "Operators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operators",
                table: "Operators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Operators_OperatorId",
                table: "ApplicationOwnerAndOperators",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Operators_OperatorId",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operators",
                table: "Operators");

            migrationBuilder.RenameTable(
                name: "Operators",
                newName: "Operator");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operator",
                table: "Operator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Operator_OperatorId",
                table: "ApplicationOwnerAndOperators",
                column: "OperatorId",
                principalTable: "Operator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
