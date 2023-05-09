using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techTask2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Owners_OwnerId",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Transports_TransportId",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationOwnerAndOperators",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropColumn(
                name: "OperatorFullName",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.RenameTable(
                name: "ApplicationOwnerAndOperators",
                newName: "Applications");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationOwnerAndOperators_TransportId",
                table: "Applications",
                newName: "IX_Applications_TransportId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationOwnerAndOperators_OwnerId",
                table: "Applications",
                newName: "IX_Applications_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Owners_OwnerId",
                table: "Applications",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Transports_TransportId",
                table: "Applications",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Owners_OwnerId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Transports_TransportId",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "ApplicationOwnerAndOperators");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_TransportId",
                table: "ApplicationOwnerAndOperators",
                newName: "IX_ApplicationOwnerAndOperators_TransportId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_OwnerId",
                table: "ApplicationOwnerAndOperators",
                newName: "IX_ApplicationOwnerAndOperators_OwnerId");

            migrationBuilder.AddColumn<string>(
                name: "OperatorFullName",
                table: "ApplicationOwnerAndOperators",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "ApplicationOwnerAndOperators",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationOwnerAndOperators",
                table: "ApplicationOwnerAndOperators",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Owners_OwnerId",
                table: "ApplicationOwnerAndOperators",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Transports_TransportId",
                table: "ApplicationOwnerAndOperators",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
