using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace techTask2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Iin = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Iin = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    Grnz = table.Column<string>(type: "text", nullable: true),
                    Vin = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Marca = table.Column<string>(type: "text", nullable: true),
                    HaveSrts = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transport_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationOwnerAndOperators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    TransportId = table.Column<int>(type: "integer", nullable: false),
                    OperatorId = table.Column<int>(type: "integer", nullable: false),
                    OperatorFullName = table.Column<string>(type: "text", nullable: true),
                    OwnerFirstName = table.Column<string>(type: "text", nullable: true),
                    OwnerLastName = table.Column<string>(type: "text", nullable: true),
                    OwnerIin = table.Column<string>(type: "text", nullable: true),
                    OwnerAddress = table.Column<string>(type: "text", nullable: true),
                    OwnerRegion = table.Column<string>(type: "text", nullable: true),
                    TransportGrnz = table.Column<string>(type: "text", nullable: true),
                    TransportVin = table.Column<string>(type: "text", nullable: true),
                    TransportCategory = table.Column<string>(type: "text", nullable: true),
                    TransportMarca = table.Column<string>(type: "text", nullable: true),
                    AppType = table.Column<string>(type: "text", nullable: true),
                    AppStatus = table.Column<string>(type: "text", nullable: true),
                    AppTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationOwnerAndOperators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationOwnerAndOperators_Operator_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationOwnerAndOperators_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationOwnerAndOperators_Transport_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Srts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    TransportId = table.Column<int>(type: "integer", nullable: false),
                    OwnerFullName = table.Column<string>(type: "text", nullable: true),
                    OwnerRegion = table.Column<string>(type: "text", nullable: true),
                    TransportGrnz = table.Column<string>(type: "text", nullable: true),
                    TransportVin = table.Column<string>(type: "text", nullable: true),
                    TransportCategory = table.Column<string>(type: "text", nullable: true),
                    SrtsNumber = table.Column<string>(type: "text", nullable: true),
                    Sign = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Srts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Srts_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Srts_Transport_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationOwnerAndOperators_OperatorId",
                table: "ApplicationOwnerAndOperators",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationOwnerAndOperators_OwnerId",
                table: "ApplicationOwnerAndOperators",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationOwnerAndOperators_TransportId",
                table: "ApplicationOwnerAndOperators",
                column: "TransportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Srts_OwnerId",
                table: "Srts",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Srts_TransportId",
                table: "Srts",
                column: "TransportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transport_OwnerId",
                table: "Transport",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationOwnerAndOperators");

            migrationBuilder.DropTable(
                name: "Srts");

            migrationBuilder.DropTable(
                name: "Operator");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
