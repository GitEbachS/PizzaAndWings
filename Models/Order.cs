using System.ComponentModel.DataAnnotations;
namespace PizzaAndWings.Models;

public class Order
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }
    public decimal Tip { get; set; }
    public int PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; }
    public int OrderTypeId { get; set; }
    public OrderType OrderType { get; set; }
    public ICollection<Item> Items { get; set; }
    public DateTime DateCreated { get; set; }
}
