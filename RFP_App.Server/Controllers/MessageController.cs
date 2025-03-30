using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.DTOs;
using System.Security.Claims;

namespace RFP_APP.Server.Controllers{
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
                ProposalId = messageDto.ProposalId
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessageById(int id)
        {
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
                return NotFound();

            return Ok(message);
        }

        // Delete a message
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
                return NotFound();

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}