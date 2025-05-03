using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.DTOs;
using System.Security.Claims;

namespace RFP_APP.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MessageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Send a message
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto messageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var message = new Message
            {
                Content = messageDto.Content,
                SentAt = DateTime.UtcNow,
                SenderId = userId,
                ReceiverId = messageDto.ReceiverId,
                ProposalId = messageDto.ProposalId,
                IsRead = messageDto.isRead
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessageById), new { id = message.Id }, message);
        }

        // Get messages for the logged-in user
        [HttpGet("inbox")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetInbox()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var messages = await _context.Messages
                .Where(m => m.ReceiverId == userId)
                .OrderByDescending(m => m.SentAt)
                .Select(m => new MessageDto
                {
                    Id = m.Id,
                    Content = m.Content,
                    ReceiverId = m.ReceiverId,
                    ProposalId = m.ProposalId
                })
                .ToListAsync();

            return Ok(messages);
        }


        // Get sent messages for the logged-in user
        [HttpGet("sent")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetSentMessages()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var messages = await _context.Messages
                .Where(m => m.SenderId == userId)
                .OrderByDescending(m => m.SentAt)
                .Select(m => new MessageDto
                {
                    Id = m.Id,
                    Content = m.Content,
                    ReceiverId = m.ReceiverId,
                    ProposalId = m.ProposalId
                })
                .ToListAsync();

            return Ok(messages);
        }


        // Get a specific message
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> GetMessageById(int id)
        {
            var message = await _context.Messages
                .Where(m => m.Id == id)
                .Select(m => new MessageDto
                {
                    Id = m.Id,
                    Content = m.Content,
                    ReceiverId = m.ReceiverId,
                    ProposalId = m.ProposalId
                })
                .FirstOrDefaultAsync();

            if (message == null)
                return NotFound();

            return Ok(message);
        }

        // TODO: modify logic so user can only delete their inbox/sent messages. 
        // Delete a message
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("Admin");

            var message = await _context.Messages.FindAsync(id);
            if (message == null)
                return NotFound(new { message = "Message not found." });

            // Only allow delete if user is sender/receiver OR an admin
            if (message.SenderId != userId && message.ReceiverId != userId && !isAdmin)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { message = "You do not have permission to delete this message." });
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Message deleted successfully." });
        }
    }
}