using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.Repositories;
using RFP_APP.Server.Repositories.Interfaces;
using RFP_APP.Server.Services;
using RFP_APP.Server.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configure SQLite Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString)
           .UseLazyLoadingProxies());  // Use lazy loading proxies here

// Configure Dependency Injection
builder.Services.AddScoped<IServiceRequestRepository, ServiceRequestRepository>();
builder.Services.AddScoped<IServiceRequestService, ServiceRequestService>();
builder.Services.AddScoped<IProposalRepository, ProposalRepository>();
builder.Services.AddScoped<IProposalService, ProposalService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// Configure Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Configure JWT Authentication
var secretKey = builder.Configuration["Jwt:SecretKey"];
if (string.IsNullOrEmpty(secretKey))
{
    throw new ArgumentNullException("Jwt:SecretKey configuration value is required.");
}

var key = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"]
    };
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:5173", // For local dev
                "https://fictional-adventure-xpr7g997w62pgjq-5173.app.github.dev")// For Codespace)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
    );
});

builder.Services.AddAuthorization();

// Add Controllers
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
// Add to support JWT Bearer token to swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by a space and your JWT token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();

// Enable Swagger in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

// Seed roles and users
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    // Seed roles
    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Static user IDs
    var adminId = "admin-id";
    var user1Id = "user1-id";
    var user2Id = "user2-id";

    // Seed Admin user
    var adminEmail = builder.Configuration["AdminCredentials:Email"];
    var adminPassword = builder.Configuration["AdminCredentials:Password"];

    if (string.IsNullOrEmpty(adminEmail) || string.IsNullOrEmpty(adminPassword))
    {
        throw new ArgumentNullException("Admin credentials are missing in the configuration.");
    }

    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            Id = adminId,
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = "Admin",
            LastName = "User",
            DateOfBirth = new DateTime(1980, 1, 1),
            AccountCreated = DateTime.UtcNow,
            LastLogin = DateTime.UtcNow
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

    // Seed Regular User 1
    var user1Email = "user1@example.com";
    var user1Password = "User1@123";

    var user1 = await userManager.FindByEmailAsync(user1Email);
    if (user1 == null)
    {
        user1 = new ApplicationUser
        {
            Id = user1Id,
            UserName = user1Email,
            Email = user1Email,
            FirstName = "John",
            LastName = "Doe",
            Bio = "A John Doe's user profile",
            DateOfBirth = new DateTime(1990, 5, 20),
            ProfilePictureUrl = "/profile-pictures/JohnDoe.png",
            AccountCreated = DateTime.UtcNow,
            LastLogin = DateTime.UtcNow
        };

        var result = await userManager.CreateAsync(user1, user1Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user1, "User");
        }
    }

    // Seed Regular User 2
    var user2Email = "user2@example.com";
    var user2Password = "User2@123";

    var user2 = await userManager.FindByEmailAsync(user2Email);
    if (user2 == null)
    {
        user2 = new ApplicationUser
        {
            Id = user2Id,
            UserName = user2Email,
            Email = user2Email,
            FirstName = "Jane",
            LastName = "Smith",
            Bio = "A Jane Smith's user profile",
            ProfilePictureUrl = "/profile-pictures/JaneSmith.png",
            DateOfBirth = new DateTime(1992, 9, 15),
            AccountCreated = DateTime.UtcNow,
            LastLogin = DateTime.UtcNow
        };

        var result = await userManager.CreateAsync(user2, user2Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user2, "User");
        }
    }
}

app.Run();