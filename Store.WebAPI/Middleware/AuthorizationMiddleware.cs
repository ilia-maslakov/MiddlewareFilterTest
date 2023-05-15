using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Store.WebAPI.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Если пользователь не авторизован и запрашивает ресурс /token, то разрешаем доступ без проверки прав.
            if (context.Request.Path == "/token")
            {
                await _next(context);
                return;
            }
            if (!((ClaimsIdentity)context.User.Identity).IsAuthenticated)
            {
                // Если пользователь не авторизован, то возвращаем ошибку 401 Unauthorized и завершаем обработку запроса.
                context.Response.StatusCode = 401;
                return;
            }

            // Проверяем, является ли атрибут [Authorize(Roles = "admin")] заданным для данного действия
            var authorizeAttribute = context.GetEndpoint()?.Metadata.GetMetadata<AuthorizeAttribute>();
            if (authorizeAttribute == null)
            {
                await _next(context);
                return;
            }
            else
            {
                var requiredRoles = authorizeAttribute.Roles.Split(',');
                if (!requiredRoles.Any(role => ((ClaimsIdentity)context.User.Identity).HasClaim(ClaimTypes.Role, role.Trim())))
                {
                    // Если у пользователя нет требуемой роли, то возвращаем ошибку 403 Forbidden и завершаем обработку запроса.
                    context.Response.StatusCode = 403;
                    return;
                }
            }
            await _next(context);
        }
    }
}
