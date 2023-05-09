using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace techTask2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applications_TransportId",
                table: "Applications");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_TransportId",
                table: "Applications",
                column: "TransportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applications_TransportId",
                table: "Applications");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_TransportId",
                table: "Applications",
                column: "TransportId",
                unique: true);
        }
    }
}
