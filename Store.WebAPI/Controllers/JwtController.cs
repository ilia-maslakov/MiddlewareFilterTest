using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Store.DataContext.Context;
using Store.DataContext.Entities;
using Store.WebAPI.Configuration;
using Store.WebAPI.Services;
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
        private readonly IIdentityService _identityService;

        public AccountController(IStoreDbContext ctx, IOptions<AuthServerOptions> authServerOptions, IIdentityService identityService)
        {
            _authServerOptions = authServerOptions.Value;
            _passwordHasher = new PasswordHasher<User>();
            _ctx = ctx;
            _identityService = identityService;

        }

        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {

            var identity = _identityService.GetIdentity(username, password);
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

            var identity = _identityService.GetIdentity(username, password);
            if (identity == null)
            {
                var newuser = new User()
                {
                    Login = username,
                    Name = username,
                    Email = email,
                    Hash = hashedPassword,
                    Role = isAdmin ?? 0
                };
                _ctx.Users.Add(newuser);
                _ctx.SaveChanges();

                return Ok(newuser);
            }

            return BadRequest(new { errorText = "User already exists." });
        }
    }
}
