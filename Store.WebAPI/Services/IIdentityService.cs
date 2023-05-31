using System.Security.Claims;

namespace Store.WebAPI.Services
{
    /// <summary>Сервис для работы с идентификацией пользователей</summary>
    public interface IIdentityService
    {
        /// <summary>Получает идентификационные данные пользователя</summary>
        ClaimsIdentity? GetIdentity(string username, string password);
    }
}
