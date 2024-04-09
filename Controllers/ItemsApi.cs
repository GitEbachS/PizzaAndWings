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

                // Add the item to the order and recalculate the total
                order.AddItem(orderItem);

                await db.SaveChangesAsync();
                return Results.Ok();
            });

            // Delete item from order
            app.MapDelete("/api/orders/{orderId}/items/{orderItemId}", async (PizzaAndWingsDbContext db, int orderId, int orderItemId) =>
            {
                // Find the order by its ID
                Order order = await db.Orders
                                      .Include(o => o.Items)
                                      .FirstOrDefaultAsync(o => o.Id == orderId);

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                // Find the OrderItem by its Id
                OrderItem orderItem = order.Items.FirstOrDefault(oi => oi.Id == orderItemId);

                if (orderItem == null)
                {
                    return Results.NotFound("Order item not found.");
                }

                // Remove the OrderItem from the order
                order.RemoveItem(orderItem);

                // Remove the OrderItem from the database
                db.OrderItems.Remove(orderItem);

                // Save changes to the database
                await db.SaveChangesAsync();

                return Results.Ok("Item removed from order successfully.");
            });
        }
    }
}

