using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using RFP_APP.Server.Models;
using RFP_APP.Server.DTOs;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api/[controller]")]
public class ApplicationUserController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;

    public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    // Register a new user
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            LastLogin = DateTime.UtcNow,
            AccountCreated = DateTime.UtcNow
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        // Add user to "User" role
        await _userManager.AddToRoleAsync(user, "User");

        return StatusCode(StatusCodes.Status201Created, new { message = "User registered successfully" });
    }

    // Login and return JWT Token
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null) return Unauthorized(new { message = "Invalid credentials" });
        if (user.UserName == null) return Unauthorized(new { message = "Username is null" });

        var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);

        if (!result.Succeeded)
            return Unauthorized(new { message = "Invalid credentials" });

        // Generate JWT Token
        var token = await GenerateJwtToken(user);

        return Ok(new
        {
            token,
            user = new
            {
                id = user.Id,
                email = user.Email
            }
        });
    }

    // Get all users (Admin only, JWT protected)
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
    {
        var users = _userManager.Users.ToList();
        return Task.FromResult<ActionResult<IEnumerable<ApplicationUser>>>(Ok(users));
    }

    // Delete a user (Admin only, JWT protected)
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { message = "User deleted successfully" });
    }

    // JWT Token Generation
    private async Task<string> GenerateJwtToken(ApplicationUser user)
    {
        // Validate user object
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(user.Id) || string.IsNullOrWhiteSpace(user.Email))
        {
            throw new ArgumentException("User ID and email cannot be null or empty.");
        }

        // Retrieve user roles
        var userRoles = await _userManager.GetRolesAsync(user);
        if (userRoles == null)
        {
            throw new InvalidOperationException("Failed to retrieve user roles.");
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            throw new ArgumentException("User email cannot be null or empty.", nameof(user.Email));
        }

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique Token ID
        };

        // Add user roles to claims
        authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        // Validate JWT configuration settings
        string jwtSecret = _configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException("JWT Secret is missing.");
        string jwtIssuer = _configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT Issuer is missing.");
        string jwtAudience = _configuration["Jwt:Audience"] ?? throw new InvalidOperationException("JWT Audience is missing.");


        if (string.IsNullOrWhiteSpace(jwtSecret) || string.IsNullOrWhiteSpace(jwtIssuer) || string.IsNullOrWhiteSpace(jwtAudience))
        {
            throw new InvalidOperationException("JWT configuration values cannot be null or empty.");
        }

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            expires: DateTime.UtcNow.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
