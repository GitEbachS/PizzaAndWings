using System.ComponentModel.DataAnnotations;
namespace PizzaAndWings.Models;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal OrderPrice { get; set; }
    public List<OrderItem> Order {  get; set; }

}
