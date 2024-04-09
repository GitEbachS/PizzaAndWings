﻿using System.ComponentModel.DataAnnotations;
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
    public decimal ItemTotal { get; set; }
    public decimal TotalWithTip => ItemTotal + Tip;
    public decimal Tip { get; set; }
    public int? PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; }
    public int OrderTypeId { get; set; }
    public OrderType OrderType { get; set; }
    public List<OrderItem>? Items { get; set; }
    public Order()
    {
        Items = new List<OrderItem>();
    }
    public DateTime? DateClosed { get; set; }


    // Method to calculate the total price of all items in the order
    public void CalculateItemTotal()
    {
        if (Items == null)
        {
            ItemTotal = 0;
            return;
        }

        ItemTotal = Items.Sum(orderItem => orderItem.Item.OrderPrice);
    }
 
}

