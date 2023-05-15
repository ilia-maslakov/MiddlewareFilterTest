namespace Store.DataContext.Entities;

/// <summary>Таблица пользователей</summary>
public class User
{
    /// <summary>Идентификатор пользователя</summary>
    public Guid Id { get; set; }

    /// <summary>Имя</summary>
    public string Name { get; set; }

    /// <summary>Электро.почта</summary>
    public string Email { get; set; }

    /// <summary>Логин</summary>
    public string Login { get; set; }
    public string? Hash { get; set; }

    ///<summary>Роль</summary>
    public int Role { get; set; }
}
