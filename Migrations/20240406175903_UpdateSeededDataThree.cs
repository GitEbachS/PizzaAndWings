using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaAndWings.Migrations
{
    public partial class UpdateSeededDataThree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: true);
        }
    }
}
