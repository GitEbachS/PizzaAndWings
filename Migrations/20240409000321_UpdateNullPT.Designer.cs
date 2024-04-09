﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PizzaAndWings.Migrations
{
    [DbContext(typeof(PizzaAndWingsDbContext))]
    [Migration("20240409000321_UpdateNullPT")]
    partial class UpdateNullPT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PizzaAndWings.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pepperoni Pizza",
                            OrderPrice = 15.99m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cheese Pizza",
                            OrderPrice = 26.50m
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hot Wings",
                            OrderPrice = 10.00m
                        },
                        new
                        {
                            Id = 4,
                            Name = "Meaty Pizza",
                            OrderPrice = 12.00m
                        },
                        new
                        {
                            Id = 5,
                            Name = "Supreme Pizza",
                            OrderPrice = 12.00m
                        },
                        new
                        {
                            Id = 6,
                            Name = "BBQ Wings",
                            OrderPrice = 13.00m
                        },
                        new
                        {
                            Id = 7,
                            Name = "Boneless Wings",
                            OrderPrice = 14.00m
                        },
                        new
                        {
                            Id = 8,
                            Name = "Buffalo Wings",
                            OrderPrice = 12.00m
                        },
                        new
                        {
                            Id = 9,
                            Name = "Cheese Stuffed Crust Pizza",
                            OrderPrice = 22.00m
                        });
                });

            modelBuilder.Entity("PizzaAndWings.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ItemTotal")
                        .HasColumnType("numeric");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Tip")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OrderTypeId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateClosed = new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "shari@shari.com",
                            FirstName = "Shari",
                            ItemTotal = 0m,
                            LastName = "Berry",
                            OrderTypeId = 2,
                            PaymentTypeId = 1,
                            Phone = "615-999-7777",
                            Status = false,
                            Tip = 6.00m
                        },
                        new
                        {
                            Id = 2,
                            DateClosed = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Joey@yahoo.com",
                            FirstName = "Joey",
                            ItemTotal = 0m,
                            LastName = "Boe",
                            OrderTypeId = 1,
                            PaymentTypeId = 2,
                            Phone = "615-322-7337",
                            Status = false,
                            Tip = 9.00m
                        },
                        new
                        {
                            Id = 3,
                            DateClosed = new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tim@gmail.com",
                            FirstName = "Tim",
                            ItemTotal = 0m,
                            LastName = "Ebert",
                            OrderTypeId = 1,
                            PaymentTypeId = 3,
                            Phone = "615-229-2227",
                            Status = false,
                            Tip = 6.00m
                        },
                        new
                        {
                            Id = 4,
                            DateClosed = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "Sam@gmail.com",
                            FirstName = "Sam",
                            ItemTotal = 0m,
                            LastName = "Hill",
                            OrderTypeId = 2,
                            PaymentTypeId = 1,
                            Phone = "615-555-9997",
                            Status = false,
                            Tip = 7.00m
                        });
                });

            modelBuilder.Entity("PizzaAndWings.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("PizzaAndWings.Models.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "In Person"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Phone"
                        });
                });

            modelBuilder.Entity("PizzaAndWings.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Card"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Cash"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Check"
                        });
                });

            modelBuilder.Entity("PizzaAndWings.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "shariebach@gmail.com",
                            Name = "Shari Ebach"
                        });
                });

            modelBuilder.Entity("PizzaAndWings.Models.Order", b =>
                {
                    b.HasOne("PizzaAndWings.Models.OrderType", "OrderType")
                        .WithMany()
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaAndWings.Models.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId");

                    b.Navigation("OrderType");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("PizzaAndWings.Models.OrderItem", b =>
                {
                    b.HasOne("PizzaAndWings.Models.Item", "Item")
                        .WithMany("Order")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaAndWings.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaAndWings.Models.Item", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaAndWings.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
