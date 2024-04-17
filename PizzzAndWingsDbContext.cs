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
        new Item {Id = 1, Name = "Pepperoni Pizza", Image = "https://img.freepik.com/free-photo/delicious-salami-pizza_1004-25.jpg?w=1060&t=st=1695335449~exp=1695336049~hmac=d1295d34e9c24f8fe810a224c6d9df4f57187cf53d9821936ee6f19841d93ec4", OrderPrice = 15.99M},
        new Item {Id = 2, Name = "Cheese Pizza", Image = "https://www.fearlessdining.com/wp-content/uploads/2022/01/gluten-free-pizza-baked.jpg", OrderPrice = 26.50M},
        new Item {Id = 3, Name = "Hot Wings", Image = "https://img.freepik.com/premium-photo/bowl-buffalo-wings-with-blue-cheese-dip_165536-1438.jpg?w=740", OrderPrice = 10.00M},
        new Item {Id = 4, Name = "Meaty Pizza", Image = "https://img.freepik.com/free-photo/grilled-buffalo-chicken-wings-rustic-wood-plate-generated-by-ai_188544-26049.jpg?t=st=1695269635~exp=1695273235~hmac=3648a5821bd73b68656d30e830d1cf119f11e710dd2f8f16a435f7eee2ea1f3d&w=740", OrderPrice = 12.00M},
        new Item {Id = 5, Name = "Supreme Pizza", Image = "https://cdn.pixabay.com/photo/2014/07/08/12/34/pizza-386717_1280.jpg", OrderPrice = 12.00M},
        new Item {Id = 6, Name = "BBQ Wings", Image = "https://img.freepik.com/premium-photo/delicious-juicy-grilled-chicken-meat-bites-with-salt-spices-herbs-dark-concrete-background_73989-48890.jpg?w=740", OrderPrice = 13.00M},
        new Item {Id = 7, Name = "Boneless Wings", Image = "https://img.freepik.com/premium-photo/delicious-juicy-grilled-chicken-meat-bites-with-salt-spices-herbs-dark-concrete-background_73989-48890.jpg?w=740", OrderPrice = 14.00M},
        new Item {Id = 8, Name = "Buffalo Wings", Image = "https://img.freepik.com/free-photo/baked-chicken-wings-asian-style_2829-10160.jpg?w=740&t=st=1695269789~exp=1695270389~hmac=45183c312a4fc8069a1c31d0bd28eb43dc76b80028f737610a49fa1c4f859b97", OrderPrice = 12.00M},
        new Item {Id = 9, Name = "Cheese Stuffed Crust Pizza", Image = "https://images.unsplash.com/photo-1594007654729-407eedc4be65?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1328&q=80", OrderPrice = 22.00M}
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