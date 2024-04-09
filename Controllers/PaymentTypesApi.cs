using PizzaAndWings.Models;
using PizzaAndWings.Dto;
using Microsoft.EntityFrameworkCore;

namespace PizzaAndWings.Controllers
{
    public class PaymentTypesApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/api/paymentTypes", (PizzaAndWingsDbContext db) =>
            {
                var paymentTypeList = db.PaymentTypes.ToList();
                return Results.Ok(paymentTypeList);

            });
        }
    }
}
