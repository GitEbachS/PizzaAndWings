using Microsoft.EntityFrameworkCore;

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
                            OrderItem = orderItem.Item.Name, 
                            OrderPrice = orderItem.Item.OrderPrice
                        })
                    })
                    .ToList();

                return Results.Ok(orders);
            });
        }
    }
}
