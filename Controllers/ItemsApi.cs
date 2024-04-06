using PizzaAndWings.Models;
using PizzaAndWings.Dto;
using Microsoft.EntityFrameworkCore;

namespace PizzaAndWings.Controllers
{
    public class ItemsApi
    {
        public static void Map(WebApplication app)
        {
            //add item to order
            app.MapPost("order/addItem", async (PizzaAndWingsDbContext db, AddItemToOrderDto addItemToOrderDto) =>
            {
                Order order = await db.Orders
                                    .FirstOrDefaultAsync(o => o.Id == addItemToOrderDto.OrderId);
                if (order == null)
                {
                    return Results.NotFound();
                }

                Item item = await db.Items
                               .FirstOrDefaultAsync(i => i.Id == addItemToOrderDto.ItemId);
                if (item == null)
                {
                    return Results.NotFound();
                }

                OrderItem orderItem = new()
                {
                    Item = item,
                    Order = order
                };

                order.Items.Add(orderItem);
                await db.SaveChangesAsync();
                return Results.Ok();
            });
        }
        }
}
