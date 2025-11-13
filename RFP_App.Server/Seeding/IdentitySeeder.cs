using Microsoft.AspNetCore.Identity;
using RFP_APP.Server.Models;

namespace RFP_APP.Server.Seeding;

public sealed class IdentitySeeder : IIdentitySeeder
{
    private readonly UserManager<ApplicationUser> _users;
    private readonly RoleManager<IdentityRole> _roles;
    private readonly IConfiguration _config;

    // static IDs so FKs line up
    public const string AdminId = "admin-id";
    public const string User1Id = "user1-id";
    public const string User2Id = "user2-id";

    public IdentitySeeder(UserManager<ApplicationUser> users, RoleManager<IdentityRole> roles, IConfiguration config)
    {
        _users = users; _roles = roles; _config = config;
    }

    public async Task SeedAsync()
    {
        foreach (var role in new[] { "Admin", "User" })
            if (!await _roles.RoleExistsAsync(role))
                await _roles.CreateAsync(new IdentityRole(role));

        var adminEmail = _config["AdminCredentials:Email"]!;
        var adminPwd   = _config["AdminCredentials:Password"]!;
        await EnsureUserAsync(AdminId, adminEmail, adminPwd, "Admin", "User", "Admin");
        await EnsureUserAsync(User1Id, "user1@example.com", "User1@123", "John", "Doe", "User");
        await EnsureUserAsync(User2Id, "user2@example.com", "User2@123", "Jane", "Smith", "User");
    }

    private async Task EnsureUserAsync(string id, string email, string pwd, string first, string last, string role)
    {
        var u = await _users.FindByEmailAsync(email);
        if (u != null) return;

        u = new ApplicationUser {
            Id = id, UserName = email, Email = email,
            FirstName = first, LastName = last,
            DateOfBirth = new DateTime(1990,1,1),
            AccountCreated = DateTime.UtcNow, LastLogin = DateTime.UtcNow
        };
        var create = await _users.CreateAsync(u, pwd);
        if (create.Succeeded) await _users.AddToRoleAsync(u, role);
    }
}
