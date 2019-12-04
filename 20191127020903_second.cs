using Microsoft.EntityFrameworkCore.Migrations;

namespace Silver_Inventory.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Items",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
