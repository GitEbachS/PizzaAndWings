using PizzaAndWings.Models;
using PizzaAndWings.Dto;
using Microsoft.EntityFrameworkCore;

namespace PizzaAndWings.Controllers
{
    public class OrderTypesApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/orderTypes", (PizzaAndWingsDbContext db) =>
            {
                var orderTypeList = db.OrderTypes.ToList();
                return Results.Ok(orderTypeList);
            });
        }
            
    }
}
