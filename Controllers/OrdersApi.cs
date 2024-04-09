using Microsoft.EntityFrameworkCore;
using PizzaAndWings.Models;
using PizzaAndWings.Dto;
using System.ComponentModel.DataAnnotations;

namespace PizzaAndWings.Controllers
{
    public class OrdersApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/orders", (PizzaAndWingsDbContext db) =>
            {
                var orders = db.Orders
                    .Include(o => o.Items)
                    .Include(o => o.PaymentType)
                    .Include(o => o.OrderType)
                    .Where(o => o.DateClosed <= DateTime.UtcNow)
                    .OrderByDescending(o => o.DateClosed)
                    .Select(o => new
                    {
                        o.Id,
                        FullName = $"{o.FirstName} {o.LastName}",
                        o.Email,
                        DateClosed = o.DateClosed.HasValue ? o.DateClosed.Value.ToString("MM/dd/yyyy") : null,

                        o.Phone,
                        o.OrderTypeId,
                        OrderType = o.OrderType.Type,
                        o.Status,
                        ItemTotal = o.ItemTotal, // Use ItemTotal property instead of Total
                        o.Tip,
                        o.PaymentTypeId,
                        PaymentType = o.PaymentType.Type,
                        TotalWithTip = o.TotalWithTip, // Use TotalWithTip property instead of Total
                        Items = o.Items.Select(orderItem => new
                        {
                            orderItem.Id,
                            Name = orderItem.Item.Name, 
                            OrderPrice = orderItem.Item.OrderPrice
                        })
                    })
                    .ToList();

                return Results.Ok(orders);

            });

            //create new order
            // create new order
            app.MapPost("/api/orders/new", (PizzaAndWingsDbContext db, CreateOrderDto orderDto) =>
            {
                
                    Order newOrder = new()
                    {
                        FirstName = orderDto.FirstName,
                        LastName = orderDto.LastName,
                        Email = orderDto.Email,
                        Phone = orderDto.Phone,
                        OrderTypeId = orderDto.OrderTypeId,
                        Status = true,
                    };

                    db.Orders.Add(newOrder);
                    db.SaveChanges();

                    return Results.Created($"/api/orders/{newOrder.Id}", newOrder);
               
            });
            app.MapPut("/api/orders/{orderId}", (PizzaAndWingsDbContext db, int orderId, Order updatedOrder) =>
{
                var orderToUpdate = db.Orders.SingleOrDefault(o => o.Id == orderId);

                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }

                orderToUpdate.FirstName = updatedOrder.FirstName;
                orderToUpdate.LastName = updatedOrder.LastName;     
                orderToUpdate.Email = updatedOrder.Email;
                orderToUpdate.Phone = updatedOrder.Phone;
                orderToUpdate.OrderTypeId = updatedOrder.OrderTypeId;

                db.SaveChanges();

                return Results.Ok(orderToUpdate);
            });

        }
    }
}
