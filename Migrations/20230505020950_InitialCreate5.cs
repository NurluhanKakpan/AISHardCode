using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace techTask2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Operators_OperatorId",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Transport_TransportId",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropForeignKey(
                name: "FK_Srts_Transport_TransportId",
                table: "Srts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transport_Owners_OwnerId",
                table: "Transport");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationOwnerAndOperators_OperatorId",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transport",
                table: "Transport");

            migrationBuilder.RenameTable(
                name: "Transport",
                newName: "Transports");

            migrationBuilder.RenameIndex(
                name: "IX_Transport_OwnerId",
                table: "Transports",
                newName: "IX_Transports_OwnerId");

            migrationBuilder.AddColumn<string>(
                name: "Psc",
                table: "ApplicationOwnerAndOperators",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transports",
                table: "Transports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Transports_TransportId",
                table: "ApplicationOwnerAndOperators",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Srts_Transports_TransportId",
                table: "Srts",
                column: "TransportId",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transports_Owners_OwnerId",
                table: "Transports",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Transports_TransportId",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.DropForeignKey(
                name: "FK_Srts_Transports_TransportId",
                table: "Srts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transports_Owners_OwnerId",
                table: "Transports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transports",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "Psc",
                table: "ApplicationOwnerAndOperators");

            migrationBuilder.RenameTable(
                name: "Transports",
                newName: "Transport");

            migrationBuilder.RenameIndex(
                name: "IX_Transports_OwnerId",
                table: "Transport",
                newName: "IX_Transport_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transport",
                table: "Transport",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Iin = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationOwnerAndOperators_OperatorId",
                table: "ApplicationOwnerAndOperators",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Operators_OperatorId",
                table: "ApplicationOwnerAndOperators",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationOwnerAndOperators_Transport_TransportId",
                table: "ApplicationOwnerAndOperators",
                column: "TransportId",
                principalTable: "Transport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Srts_Transport_TransportId",
                table: "Srts",
                column: "TransportId",
                principalTable: "Transport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transport_Owners_OwnerId",
                table: "Transport",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
