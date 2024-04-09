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

                db.OrderItems.Add(orderItem);

                await db.SaveChangesAsync();
                return Results.Ok();
            });

            // Delete item from order
            app.MapDelete("/api/items/{orderId}/remove/{itemId}", (PizzaAndWingsDbContext db, int orderId, int itemId) =>
            {
                OrderItem orderItemToDelete = db.OrderItems
                                              .Where(oi => oi.Order.Id == orderId)
                                              .Where(oi => oi.Item.Id == itemId)
                                               .FirstOrDefault();
                if (orderItemToDelete == null)
                {
                    return Results.NotFound();
                }

                db.OrderItems.Remove(orderItemToDelete);
                db.SaveChanges();
                return Results.NoContent();
            });

        }
    }
}

