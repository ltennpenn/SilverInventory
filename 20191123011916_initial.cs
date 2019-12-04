using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Silver_Inventory.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChestName = table.Column<string>(maxLength: 50, nullable: false),
                    ItemName = table.Column<string>(nullable: false),
                    ItemType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    ItemYear = table.Column<string>(nullable: true),
                    Grade = table.Column<string>(nullable: true),
                    Strike = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<string>(nullable: true),
                    PurchaseAmount = table.Column<decimal>(nullable: false),
                    NurismaticAmount = table.Column<decimal>(nullable: false),
                    MeltAmount = table.Column<decimal>(nullable: false),
                    MintMark = table.Column<string>(nullable: true),
                    GradingService = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemNumber);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ItemNumber = table.Column<int>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    ChestName = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Items_ItemNumber",
                        column: x => x.ItemNumber,
                        principalTable: "Items",
                        principalColumn: "ItemNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ItemNumber",
                table: "Transactions",
                column: "ItemNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
