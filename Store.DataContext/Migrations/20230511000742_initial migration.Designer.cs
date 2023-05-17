﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Store.DataContext.Context;

#nullable disable

namespace Store.DataContext.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20230511000742_initial migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Store.DataContext.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("858c598f-4ee3-421f-84bb-fd566b4f63e7"),
                            Count = 50,
                            Description = "Premium roasted Arabica coffee beans from Colombia",
                            Name = "Organic Coffee Beans",
                            Price = 20.99m
                        },
                        new
                        {
                            Id = new Guid("34d13591-0f54-40e1-a881-84a23c7b69b3"),
                            Count = 20,
                            Description = "Eco-friendly bamboo cutting board for your kitchen",
                            Name = "Bamboo Cutting Board",
                            Price = 34.99m
                        },
                        new
                        {
                            Id = new Guid("70cc9b62-fa07-42d2-8fa1-73ee74dd6b0a"),
                            Count = 80,
                            Description = "Reusable and insulated water bottle for on-the-go hydration",
                            Name = "Stainless Steel Water Bottle",
                            Price = 22.50m
                        },
                        new
                        {
                            Id = new Guid("47aaf5ab-0085-4bc5-a2e5-0d7a17608dc9"),
                            Count = 15,
                            Description = "Pre-seasoned cast iron skillet for perfect searing and sautéing",
                            Name = "Cast Iron Skillet",
                            Price = 79.99m
                        },
                        new
                        {
                            Id = new Guid("b147c73b-9246-4ee6-95f6-9d6c30c3ef43"),
                            Count = 10,
                            Description = "Luxurious and soft organic cotton bathrobe for ultimate relaxation",
                            Name = "Organic Bathrobe",
                            Price = 129.99m
                        },
                        new
                        {
                            Id = new Guid("9d4f4bb4-b2a4-4da8-bc02-62e6f350e684"),
                            Count = 30,
                            Description = "Wireless earbuds with noise cancelling technology",
                            Name = "Bluetooth Earbuds",
                            Price = 49.99m
                        },
                        new
                        {
                            Id = new Guid("68ef1e88-59cc-48d5-8b02-7f8393220e18"),
                            Count = 25,
                            Description = "High-performance gaming mouse with customizable RGB lighting",
                            Name = "Gaming Mouse",
                            Price = 69.99m
                        },
                        new
                        {
                            Id = new Guid("b352a87a-fc24-408e-a44f-2a85cfb04e06"),
                            Count = 15,
                            Description = "Fitness tracker with heart rate monitor and GPS",
                            Name = "Smart Watch",
                            Price = 149.99m
                        },
                        new
                        {
                            Id = new Guid("a22d09c3-2a3c-4ca6-af85-62a98a9c511d"),
                            Count = 40,
                            Description = "Qi-enabled wireless charging pad for smartphones and other devices",
                            Name = "Wireless Charging Pad",
                            Price = 29.99m
                        },
                        new
                        {
                            Id = new Guid("6c9dfe36-c1ee-4f17-8d52-47be85b7c764"),
                            Count = 20,
                            Description = "Wristband fitness tracker with sleep monitor and step counter",
                            Name = "Fitness Tracker",
                            Price = 39.99m
                        },
                        new
                        {
                            Id = new Guid("f68b5571-5477-4a07-9a7a-fdb0378ebe7a"),
                            Count = 10,
                            Description = "Stainless steel electric kettle with temperature control",
                            Name = "Electric Kettle",
                            Price = 59.99m
                        },
                        new
                        {
                            Id = new Guid("05f8b7a9-5620-4c1e-a889-8c7d51a3a882"),
                            Count = 5,
                            Description = "Genuine leather messenger bag with multiple compartments",
                            Name = "Leather Messenger Bag",
                            Price = 199.99m
                        },
                        new
                        {
                            Id = new Guid("dc18dfe6-9cc7-46cc-a92c-cd3d3b0c7737"),
                            Count = 8,
                            Description = "Smart robot vacuum cleaner with voice control and scheduling",
                            Name = "Robot Vacuum Cleaner",
                            Price = 349.99m
                        },
                        new
                        {
                            Id = new Guid("61a9ce7f-6dc5-4f64-96d5-6b8ed0b5e99c"),
                            Count = 12,
                            Description = "Ionic hair dryer with multiple heat and speed settings",
                            Name = "Professional Hair Dryer",
                            Price = 79.99m
                        },
                        new
                        {
                            Id = new Guid("f5ebc37a-10c1-455f-8fb1-7c839129b96c"),
                            Count = 20,
                            Description = "Eco-friendly and non-slip yoga mat that can be easily folded",
                            Name = "Foldable Yoga Mat",
                            Price = 49.99m
                        });
                });

            modelBuilder.Entity("Store.DataContext.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("858c598f-4ee3-421f-84bb-c7308328ce3a"),
                            Email = "test@test.ru",
                            Login = "Test",
                            Name = "Test",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("5a5a8a36-3570-4eb2-95fb-343f8aa92a3a"),
                            Email = "admin@test.ru",
                            Login = "Admin",
                            Name = "Admin",
                            Role = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
