namespace PizzaAndWings.Dto
{
    public class CreateOrderDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public int OrderTypeId { get; set; }
    }
}
