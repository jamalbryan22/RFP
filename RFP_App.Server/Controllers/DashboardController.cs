using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.Models.Enums;
using RFP_APP.Server.DTOs;
using System.Security.Claims;

namespace RFP_APP.Server.Controllers
{
   [Authorize]
   [ApiController]
   [Route("api/[controller]")]
   public class DashboardController : ControllerBase
   {
      private readonly ApplicationDbContext _context;

      public DashboardController(ApplicationDbContext context)
      {
         _context = context;
      }

      [HttpGet("stats")]
      public async Task<IActionResult> GetDashboardStats()
      {
         var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
         if (userId == null) return Unauthorized();

         var openRequests = await _context.ServiceRequests
             .Where(r => r.CreatorId == userId && r.Status == ServiceRequestStatus.Open)
             .CountAsync();

         var proposals = await _context.Proposals
             .Where(p => p.CreatorId == userId && p.Status == ProposalStatus.Accepted)
             .CountAsync();

         var unreadMessages = await _context.Messages
             .Where(m => m.ReceiverId == userId && !m.IsRead)
             .CountAsync();

         return Ok(new DashboardStatsDto
         {
            OpenRequestCount = openRequests,
            ProposalCount = proposals,
            UnreadMessageCount = unreadMessages
         });
      }
   }
}