using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaAndWings.Migrations
{
    public partial class UpdateImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Tip",
                table: "Orders",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://img.freepik.com/free-photo/delicious-salami-pizza_1004-25.jpg?w=1060&t=st=1695335449~exp=1695336049~hmac=d1295d34e9c24f8fe810a224c6d9df4f57187cf53d9821936ee6f19841d93ec4");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://www.fearlessdining.com/wp-content/uploads/2022/01/gluten-free-pizza-baked.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://img.freepik.com/premium-photo/bowl-buffalo-wings-with-blue-cheese-dip_165536-1438.jpg?w=740");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://img.freepik.com/free-photo/grilled-buffalo-chicken-wings-rustic-wood-plate-generated-by-ai_188544-26049.jpg?t=st=1695269635~exp=1695273235~hmac=3648a5821bd73b68656d30e830d1cf119f11e710dd2f8f16a435f7eee2ea1f3d&w=740");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://cdn.pixabay.com/photo/2014/07/08/12/34/pizza-386717_1280.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://img.freepik.com/premium-photo/delicious-juicy-grilled-chicken-meat-bites-with-salt-spices-herbs-dark-concrete-background_73989-48890.jpg?w=740");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://img.freepik.com/premium-photo/delicious-juicy-grilled-chicken-meat-bites-with-salt-spices-herbs-dark-concrete-background_73989-48890.jpg?w=740");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://img.freepik.com/free-photo/baked-chicken-wings-asian-style_2829-10160.jpg?w=740&t=st=1695269789~exp=1695270389~hmac=45183c312a4fc8069a1c31d0bd28eb43dc76b80028f737610a49fa1c4f859b97");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "https://images.unsplash.com/photo-1594007654729-407eedc4be65?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1328&q=80");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Items");

            migrationBuilder.AlterColumn<decimal>(
                name: "Tip",
                table: "Orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);
        }
    }
}
