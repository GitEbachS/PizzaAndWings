using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using PizzaAndWings.Models;

public class PizzaAndWingsDbContext : DbContext
{

    public DbSet<Item> Items { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderType> OrderTypes { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with items
        modelBuilder.Entity<Item>().HasData(new Item[]
        {
        new Item {Id = 1, Name = "Pepperoni Pizza", OrderPrice = 15.99M},
        new Item {Id = 2, Name = "Cheese Pizza", OrderPrice = 26.50M},
        new Item {Id = 3, Name = "Hot Wings", OrderPrice = 10.00M},
        new Item {Id = 4, Name = "Meaty Pizza", OrderPrice = 12.00M},
        new Item {Id = 5, Name = "Supreme Pizza", OrderPrice = 12.00M},
        new Item {Id = 6, Name = "BBQ Wings", OrderPrice = 13.00M},
        new Item {Id = 7, Name = "Boneless Wings", OrderPrice = 14.00M},
        new Item {Id = 8, Name = "Buffalo Wings", OrderPrice = 12.00M},
        new Item {Id = 9, Name = "Cheese Stuffed Crust Pizza", OrderPrice = 22.00M}
        });
        // seed data with orders
        modelBuilder.Entity<Order>().HasData(new Order[]
        {
        new Order {Id = 1, FirstName = "Shari", LastName = "Berry", Email = "shari@shari.com", Phone = "615-999-7777", Status = false, Tip = 6.00M, PaymentTypeId = 1, OrderTypeId = 2, DateClosed = new DateTime(2024, 1, 11)},
        new Order {Id = 2, FirstName = "Joey", LastName = "Boe", Email = "Joey@yahoo.com", Phone = "615-322-7337", Status = false, Tip = 9.00M, PaymentTypeId = 2, OrderTypeId = 1, DateClosed = new DateTime(2024, 3, 15)},
        new Order {Id = 3, FirstName = "Tim", LastName = "Ebert", Email = "tim@gmail.com", Phone = "615-229-2227", Status = false, Tip = 6.00M, PaymentTypeId = 3, OrderTypeId = 1, DateClosed = new DateTime(2024, 1, 14)},
        new Order {Id = 4, FirstName = "Sam", LastName = "Hill", Email = "Sam@gmail.com", Phone = "615-555-9997", Status = false, Tip = 7.00M, PaymentTypeId = 1, OrderTypeId = 2, DateClosed = new DateTime(2024, 1, 10)},
        });

        // seed data with order types
        modelBuilder.Entity<OrderType>().HasData(new OrderType[]
      {
        new OrderType {Id = 1, Type = "In Person"},
        new OrderType {Id = 2, Type = "Phone"},
      });

      

        // seed data with payment types
        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
        {
        new PaymentType {Id = 1, Type = "Card"},
        new PaymentType {Id = 2, Type = "Cash"},
        new PaymentType {Id = 3, Type = "Check"},
        });

        // seed data with users
        modelBuilder.Entity<User>().HasData(new User[]
        {
        new User {Id = 1, Uid = null},
        });

    }
    public PizzaAndWingsDbContext(DbContextOptions<PizzaAndWingsDbContext> context) : base(context)
    {
    }
}