using Store.DataContext.Entities;

namespace Store.DataContext.SeedData
{
    public static class ProductData
    {
        public static readonly Product[] Default =
        {
            new Product { Id = new Guid("858c598f-4ee3-421f-84bb-fd566b4f63e7"), Name = "Organic Coffee Beans", Description = "Premium roasted Arabica coffee beans from Colombia", Price = 20.99M, Count = 50 },
            new Product { Id = new Guid("34d13591-0f54-40e1-a881-84a23c7b69b3"), Name = "Bamboo Cutting Board", Description = "Eco-friendly bamboo cutting board for your kitchen", Price = 34.99M, Count = 20 },
            new Product { Id = new Guid("70cc9b62-fa07-42d2-8fa1-73ee74dd6b0a"), Name = "Stainless Steel Water Bottle", Description = "Reusable and insulated water bottle for on-the-go hydration", Price = 22.50M, Count = 80 },
            new Product { Id = new Guid("47aaf5ab-0085-4bc5-a2e5-0d7a17608dc9"), Name = "Cast Iron Skillet", Description = "Pre-seasoned cast iron skillet for perfect searing and sautéing", Price = 79.99M, Count = 15 },
            new Product { Id = new Guid("b147c73b-9246-4ee6-95f6-9d6c30c3ef43"), Name = "Organic Bathrobe", Description = "Luxurious and soft organic cotton bathrobe for ultimate relaxation", Price = 129.99M, Count = 10 },
            new Product { Id = new Guid("9d4f4bb4-b2a4-4da8-bc02-62e6f350e684"), Name = "Bluetooth Earbuds", Description = "Wireless earbuds with noise cancelling technology", Price = 49.99M, Count = 30 },
            new Product { Id = new Guid("68ef1e88-59cc-48d5-8b02-7f8393220e18"), Name = "Gaming Mouse", Description = "High-performance gaming mouse with customizable RGB lighting", Price = 69.99M, Count = 25 },
            new Product { Id = new Guid("b352a87a-fc24-408e-a44f-2a85cfb04e06"), Name = "Smart Watch", Description = "Fitness tracker with heart rate monitor and GPS", Price = 149.99M, Count = 15 },
            new Product { Id = new Guid("a22d09c3-2a3c-4ca6-af85-62a98a9c511d"), Name = "Wireless Charging Pad", Description = "Qi-enabled wireless charging pad for smartphones and other devices", Price = 29.99M, Count = 40 },
            new Product { Id = new Guid("6c9dfe36-c1ee-4f17-8d52-47be85b7c764"), Name = "Fitness Tracker", Description = "Wristband fitness tracker with sleep monitor and step counter", Price = 39.99M, Count = 20 },
            new Product { Id = new Guid("f68b5571-5477-4a07-9a7a-fdb0378ebe7a"), Name = "Electric Kettle", Description = "Stainless steel electric kettle with temperature control", Price = 59.99M, Count = 10 },
            new Product { Id = new Guid("05f8b7a9-5620-4c1e-a889-8c7d51a3a882"), Name = "Leather Messenger Bag", Description = "Genuine leather messenger bag with multiple compartments", Price = 199.99M, Count = 5 },
            new Product { Id = new Guid("dc18dfe6-9cc7-46cc-a92c-cd3d3b0c7737"), Name = "Robot Vacuum Cleaner", Description = "Smart robot vacuum cleaner with voice control and scheduling", Price = 349.99M, Count = 8 },
            new Product { Id = new Guid("61a9ce7f-6dc5-4f64-96d5-6b8ed0b5e99c"), Name = "Professional Hair Dryer", Description = "Ionic hair dryer with multiple heat and speed settings", Price = 79.99M, Count = 12 },
            new Product { Id = new Guid("f5ebc37a-10c1-455f-8fb1-7c839129b96c"), Name = "Foldable Yoga Mat", Description = "Eco-friendly and non-slip yoga mat that can be easily folded", Price = 49.99M, Count = 20 },

        };
    }
}
