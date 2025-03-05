using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Models;

namespace RFP_APP.Server.Data
{
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
      {
      }

      // Add any custom DbSets here, if needed
      // Example: public DbSet<YourCustomModel> YourCustomModels { get; set; }
   }
}
