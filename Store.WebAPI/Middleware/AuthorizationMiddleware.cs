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
            // ���� ������������ �� ����������� � ����������� ������ /token, �� ��������� ������ ��� �������� ����.
            if (context.Request.Path == "/token")
            {
                await _next(context);
                return;
            }
            if (!((ClaimsIdentity)context.User.Identity).IsAuthenticated)
            {
                // ���� ������������ �� �����������, �� ���������� ������ 401 Unauthorized � ��������� ��������� �������.
                context.Response.StatusCode = 401;
                return;
            }

            // ���������, �������� �� ������� [Authorize(Roles = "admin")] �������� ��� ������� ��������
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
                    // ���� � ������������ ��� ��������� ����, �� ���������� ������ 403 Forbidden � ��������� ��������� �������.
                    context.Response.StatusCode = 403;
                    return;
                }
            }
            await _next(context);
        }
    }
}
