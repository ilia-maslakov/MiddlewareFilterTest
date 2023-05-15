namespace Store.WebAPI.Authentication.Models;

public class ApplicationUser
{
    public Guid? UserId { get; set; }

    public string? Login { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string[] Roles { get; set; }
    public string? AuthToken { get; set; }

    public bool IsUserInRole(string role) => Roles.Contains(role);


    public bool IsUserInRoles(IList<string> roles) => Roles.Intersect(roles).Any();
}
