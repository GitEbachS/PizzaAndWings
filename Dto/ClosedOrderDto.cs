﻿using PizzaAndWings.Models;
namespace PizzaAndWings.Dto
{
    public class ClosedOrderDto
    {
        public int OrderId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Tip { get; set; }

    }
}
