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
            app.MapGet("/api/orders", (PizzaAndWingsDbContext db) =>
            {
                var orders = db.Orders
                    .Include(o => o.OrderType)
                    .Where(o => o.Status == true || o.DateClosed <= DateTime.UtcNow)
                    .OrderByDescending(o => o.DateClosed.HasValue ? o.DateClosed.Value : DateTime.MaxValue) // Order by DateClosed if not null, otherwise by maximum DateTime
                    .Select(o => new
                    {
                        o.Id,
                        FullName = $"{o.FirstName} {o.LastName}",
                        o.Email,
                        DateClosed = o.DateClosed.HasValue ? o.DateClosed.Value.ToString("MM/dd/yyyy") : null,

                        o.Phone,
                        o.OrderTypeId,
                        OrderType = o.OrderType.Type,
                        o.Status
                    })
                    .ToList();

                return Results.Ok(orders);

            });

            //get the single order details
            app.MapGet("/api/order/{orderId}", (PizzaAndWingsDbContext db, int orderId) =>
            {
                var singleOrder = db.Orders
                                  .Include(o => o.Items)
                                  .ThenInclude(oi => oi.Item)
                                  .Include(o => o.PaymentType)
                                  .Include(o => o.OrderType)
                                  .Where(o => o.Id == orderId)
                                  .Select(o => new
                                  {
                                      o.Id,
                                      o.FirstName,
                                      o.LastName,
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
                                       
                                          Id = orderItem.Item.Id, // Include ItemId from OrderItem
                                          Name = orderItem.Item.Name,
                                          Image = orderItem.Item.Image,
                                          OrderPrice = orderItem.Item.OrderPrice
                                      })
                                  })
                                  .SingleOrDefault();

                if (singleOrder == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(singleOrder);
            });
        

            // create new order
            app.MapPost("/api/order/new", (PizzaAndWingsDbContext db, CreateOrderDto orderDto) =>
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

                return Results.Created($"/api/order/{newOrder.Id}", newOrder);
            });

            //update main order
            app.MapPut("/api/orders/{orderId}", (PizzaAndWingsDbContext db, int orderId, CreateOrderDto orderDto) =>
            {
                var orderToUpdate = db.Orders.SingleOrDefault(o => o.Id == orderId);

                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }

                orderToUpdate.FirstName = orderDto.FirstName;
                orderToUpdate.LastName = orderDto.LastName;
                orderToUpdate.Email = orderDto.Email;
                orderToUpdate.Phone = orderDto.Phone;
                orderToUpdate.OrderTypeId = orderDto.OrderTypeId;
                orderToUpdate.Status = true;
               

                db.SaveChanges();

                return Results.Ok(orderToUpdate);
            });

            //update closed order
            app.MapPut("/api/closedOrders/", (PizzaAndWingsDbContext db, ClosedOrderDto orderDto) =>
            {
                var orderToUpdate = db.Orders.FirstOrDefault(o => o.Id == orderDto.OrderId);

                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }

                orderToUpdate.Id = orderDto.OrderId;
                orderToUpdate.Status = false;
                orderToUpdate.PaymentTypeId = orderDto.PaymentTypeId;
                orderToUpdate.Tip = orderDto.Tip;
                orderToUpdate.DateClosed = DateTime.Now;
               

                db.SaveChanges();

                return Results.Ok(orderToUpdate);
            });

            //Delete Order
            app.MapDelete("/api/orders/{orderId}/items", async (PizzaAndWingsDbContext db, int orderId) =>
            {
                Order order = await db.Orders
                                    .Include(o => o.Items)
                                    .FirstOrDefaultAsync(o => o.Id == orderId);

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                foreach (var orderItem in order.Items)
                {
                    db.OrderItems.Remove(orderItem);
                }

                await db.SaveChangesAsync();
                return Results.Ok("Items removed from order successfully.");
            });

            // Calculate total revenue including item totals for orders with status closed
            app.MapGet("/total-revenue", (PizzaAndWingsDbContext db) =>
            {
             
                var closedOrders = db.Orders
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Item)
                    .Where(o => !o.Status)
                    .ToList(); 

                
                decimal totalItemTotal = closedOrders.Sum(o => o.ItemTotal);

                return Results.Ok(new { TotalItemTotal = totalItemTotal });
            });

            //get list of orderItems
            app.MapGet("/api/orderItems/", (PizzaAndWingsDbContext db) =>
            {
                var orderItemList = db.OrderItems
                                    .Include(oi => oi.Order)
                                    .Include(oi => oi.Item)
                                    .ToList();

                return Results.Ok(orderItemList);
              
            });



        }
    }
}

