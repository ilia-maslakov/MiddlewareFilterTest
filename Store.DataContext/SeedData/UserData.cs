using Store.DataContext.Entities;

namespace Store.DataContext.SeedData;

public static class UserData
{
    public static readonly User[] Default =
    {
        new ()
        {
            Id = new Guid("858c598f-4ee3-421f-84bb-c7308328ce3a"),
            Name = "Test",
            Email = "test@test.ru",
            Login = "Test",
            Role = 0,
        },
        new ()
        {
            Id = new Guid("5a5a8a36-3570-4eb2-95fb-343f8aa92a3a"),
            Name = "Admin",
            Email = "admin@test.ru",
            Login = "Admin",
            Role = 1,
        }
    };
}