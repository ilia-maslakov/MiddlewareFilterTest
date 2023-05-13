using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.DataContext.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Login = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Count", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("05f8b7a9-5620-4c1e-a889-8c7d51a3a882"), 5, "Genuine leather messenger bag with multiple compartments", "Leather Messenger Bag", 199.99m },
                    { new Guid("34d13591-0f54-40e1-a881-84a23c7b69b3"), 20, "Eco-friendly bamboo cutting board for your kitchen", "Bamboo Cutting Board", 34.99m },
                    { new Guid("47aaf5ab-0085-4bc5-a2e5-0d7a17608dc9"), 15, "Pre-seasoned cast iron skillet for perfect searing and sautéing", "Cast Iron Skillet", 79.99m },
                    { new Guid("61a9ce7f-6dc5-4f64-96d5-6b8ed0b5e99c"), 12, "Ionic hair dryer with multiple heat and speed settings", "Professional Hair Dryer", 79.99m },
                    { new Guid("68ef1e88-59cc-48d5-8b02-7f8393220e18"), 25, "High-performance gaming mouse with customizable RGB lighting", "Gaming Mouse", 69.99m },
                    { new Guid("6c9dfe36-c1ee-4f17-8d52-47be85b7c764"), 20, "Wristband fitness tracker with sleep monitor and step counter", "Fitness Tracker", 39.99m },
                    { new Guid("70cc9b62-fa07-42d2-8fa1-73ee74dd6b0a"), 80, "Reusable and insulated water bottle for on-the-go hydration", "Stainless Steel Water Bottle", 22.50m },
                    { new Guid("858c598f-4ee3-421f-84bb-fd566b4f63e7"), 50, "Premium roasted Arabica coffee beans from Colombia", "Organic Coffee Beans", 20.99m },
                    { new Guid("9d4f4bb4-b2a4-4da8-bc02-62e6f350e684"), 30, "Wireless earbuds with noise cancelling technology", "Bluetooth Earbuds", 49.99m },
                    { new Guid("a22d09c3-2a3c-4ca6-af85-62a98a9c511d"), 40, "Qi-enabled wireless charging pad for smartphones and other devices", "Wireless Charging Pad", 29.99m },
                    { new Guid("b147c73b-9246-4ee6-95f6-9d6c30c3ef43"), 10, "Luxurious and soft organic cotton bathrobe for ultimate relaxation", "Organic Bathrobe", 129.99m },
                    { new Guid("b352a87a-fc24-408e-a44f-2a85cfb04e06"), 15, "Fitness tracker with heart rate monitor and GPS", "Smart Watch", 149.99m },
                    { new Guid("dc18dfe6-9cc7-46cc-a92c-cd3d3b0c7737"), 8, "Smart robot vacuum cleaner with voice control and scheduling", "Robot Vacuum Cleaner", 349.99m },
                    { new Guid("f5ebc37a-10c1-455f-8fb1-7c839129b96c"), 20, "Eco-friendly and non-slip yoga mat that can be easily folded", "Foldable Yoga Mat", 49.99m },
                    { new Guid("f68b5571-5477-4a07-9a7a-fdb0378ebe7a"), 10, "Stainless steel electric kettle with temperature control", "Electric Kettle", 59.99m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Login", "Name", "Role" },
                values: new object[,]
                {
                    { new Guid("5a5a8a36-3570-4eb2-95fb-343f8aa92a3a"), "admin@test.ru", "Admin", "Admin", 1 },
                    { new Guid("858c598f-4ee3-421f-84bb-c7308328ce3a"), "test@test.ru", "Test", "Test", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                table: "Product",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_User_Login",
                table: "User",
                column: "Login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
