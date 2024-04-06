using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaAndWings.Migrations
{
    public partial class UpdateDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Orders",
                newName: "DateClosed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateClosed",
                table: "Orders",
                newName: "DateCreated");
        }
    }
}
