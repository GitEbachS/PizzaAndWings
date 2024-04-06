using System.ComponentModel.DataAnnotations;
namespace PizzaAndWings.Models;

public class Item
{
    public int Id { get; set; }
    public string OrderItem { get; set; }
    public decimal OrderPrice { get; set; }

}
