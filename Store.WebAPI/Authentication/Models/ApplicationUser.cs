namespace Store.WebAPI.Authentication.Models;

/// <summary>
/// Представляет пользователя приложения.
/// </summary>
public class ApplicationUser
{
    /// <summary>Уникальный идентификатор пользователя.</summary>
    public Guid? UserId { get; set; }

    /// <summary>Логин пользователя.</summary>
    public string? Login { get; set; }

    /// <summary>Полное имя пользователя.</summary>
    public string? FullName { get; set; }

    /// <summary>Электронная почта пользователя.</summary>
    public string? Email { get; set; }

    /// <summary>Имя пользователя.</summary>
    public string? FirstName { get; set; }

    /// <summary>Фамилия пользователя.</summary>
    public string? LastName { get; set; }

    /// <summary>Роли пользователя.</summary>
    public string[]? Roles { get; set; }

    /// <summary>Токен аутентификации пользователя.</summary>
    public string? AuthToken { get; set; }

    /// <summary>Проверяет, принадлежит ли пользователь указанной роли.</summary>
    /// <param name="role">Роль, которую требуется проверить.</param>
    /// <returns>True, если пользователь принадлежит указанной роли; в противном случае - false.</returns>
    public bool IsUserInRole(string role) => Roles?.Contains(role) ?? false;

    /// <summary>Проверяет, принадлежит ли пользователь хотя бы одной из указанных ролей.</summary>
    /// <param name="roles">Роли, которые требуется проверить.</param>
    /// <returns>True, если пользователь принадлежит хотя бы одной из указанных ролей; в противном случае - false.</returns>
    public bool IsUserInRoles(IList<string> roles) => Roles?.Intersect(roles).Any() ?? false;
}