using Microsoft.AspNetCore.Identity;
using Store.DataContext.Context;
using Store.DataContext.Entities;
using System.Security.Claims;

namespace Store.WebAPI.Services
{

    public class IdentityService : IIdentityService
    {
        public readonly IStoreDbContext _ctx;
        public readonly IPasswordHasher<User> _passwordHasher;

        public IdentityService(IStoreDbContext ctx, IPasswordHasher<User> passwordHasher)
        {
            _ctx = ctx;
            _passwordHasher = passwordHasher;
        }

        public ClaimsIdentity? GetIdentity(string username, string password)
        {
            User? user = _ctx.GetUserByUsername(username);
            if (user == null)
            {
                return null;
            }

            var result = _passwordHasher.VerifyHashedPassword(new User(), user.Hash ?? String.Empty, password);

            switch (result)
            {
                case PasswordVerificationResult.Success:
                    break;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    // Если пароль был хеширован с более слабым алгоритмом, чем сейчас используется,
                    // то перехешируем его и обновим запись в БД.
                    user.Hash = _passwordHasher.HashPassword(new User(), password);
                    _ctx.SaveChanges();
                    break;
                default:
                    return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, "USER")
            };
            if (user.Role == 1)
            {
                claims.Add(new Claim(ClaimTypes.Role, "ADMIN"));
            }
            return new ClaimsIdentity(claims.ToArray(), "Token");
        }
    }
}
