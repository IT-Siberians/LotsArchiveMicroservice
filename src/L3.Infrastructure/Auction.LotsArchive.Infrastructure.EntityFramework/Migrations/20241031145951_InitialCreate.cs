using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.LotsArchive.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    IsDeletedSoftly = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SellerId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "money", nullable: false),
                    BidIncrement = table.Column<decimal>(type: "money", nullable: false),
                    RepurchasePrice = table.Column<decimal>(type: "money", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUnpurchased = table.Column<bool>(type: "boolean", nullable: false),
                    RepurchasedLotId = table.Column<Guid>(type: "uuid", nullable: true),
                    WithdrawnLotId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_Persons_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepurchasedLots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LotId = table.Column<Guid>(type: "uuid", nullable: false),
                    BuyerId = table.Column<Guid>(type: "uuid", nullable: false),
                    HammerPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepurchasedLots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepurchasedLots_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepurchasedLots_Persons_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawnLots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LotId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawnLots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithdrawnLots_Lots_LotId",
                        column: x => x.LotId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lots_SellerId",
                table: "Lots",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_RepurchasedLots_BuyerId",
                table: "RepurchasedLots",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_RepurchasedLots_LotId",
                table: "RepurchasedLots",
                column: "LotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawnLots_LotId",
                table: "WithdrawnLots",
                column: "LotId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepurchasedLots");

            migrationBuilder.DropTable(
                name: "WithdrawnLots");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
