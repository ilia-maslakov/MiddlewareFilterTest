using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Store.DataContext.Entities;
using Store.WebAPI.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Store.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly AuthServerOptions _authServerOptions;
        private readonly IStoreDbContext _ctx;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountController(IStoreDbContext ctx, IOptions<AuthServerOptions> authServerOptions)
        {
            _authServerOptions = authServerOptions.Value;
            _passwordHasher = new PasswordHasher<User>();
            _ctx = ctx;

        }

        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {

            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }


            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: _authServerOptions.Issuer,
                audience: _authServerOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(_authServerOptions.LifetimeMinutes)),
                signingCredentials: new SigningCredentials(_authServerOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return new JsonResult(response)
            {
                StatusCode = 200
            };
        }

        [HttpPost("adduser")]
        public IActionResult AddUser(string username, string email, string password, int? isAdmin = 0)
        {
            var hashedPassword = _passwordHasher.HashPassword(new User(), password);

            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                var newuser = new User()
                {
                    Login = username,
                    Name = username,
                    Email = email,
                    Hash = hashedPassword
                };
                _ctx.Users.Add(newuser);
                _ctx.SaveChanges();

                return Ok(newuser);
            }

            return BadRequest(new { errorText = "User already exists." });
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Login == username);
            if (user == null)
            {
                return null;
            }

            var result = _passwordHasher.VerifyHashedPassword(new User(), user.Hash, password);

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
