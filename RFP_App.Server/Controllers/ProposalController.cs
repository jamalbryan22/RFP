using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.DTOs;
using System.Security.Claims;

namespace RFP_APP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProposalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProposalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/proposals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProposalResponseDto>>> GetProposals()
        {
            try
            {
                var proposals = await _context.Proposals
                    .Select(p => new ProposalResponseDto
                    {
                        Id = p.Id,
                        Description = p.Description,
                        BidAmount = p.BidAmount,
                        SubmittedAt = p.SubmittedAt,
                        Status = p.Status,
                        ServiceRequestId = p.ServiceRequestId,
                        CreatorId = p.CreatorId
                    })
                    .ToListAsync();

                return Ok(proposals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching proposals.", error = ex.Message });
            }
        }

        // GET: api/proposals/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProposalResponseDto>> GetProposal(int id)
        {
            try
            {
                var proposal = await _context.Proposals.FindAsync(id);

                if (proposal == null)
                {
                    return NotFound(new { message = "Proposal not found." });
                }

                return Ok(new ProposalResponseDto
                {
                    Id = proposal.Id,
                    Description = proposal.Description,
                    BidAmount = proposal.BidAmount,
                    SubmittedAt = proposal.SubmittedAt,
                    Status = proposal.Status,
                    ServiceRequestId = proposal.ServiceRequestId,
                    CreatorId = proposal.CreatorId
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching the proposal.", error = ex.Message });
            }
        }

        // POST: api/proposals
        [HttpPost]
        public async Task<ActionResult<ProposalResponseDto>> CreateProposal(ProposalCreateDto proposalDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated." });
            }

            var serviceRequestExists = await _context.ServiceRequests.AnyAsync(sr => sr.Id == proposalDto.ServiceRequestId);
            if (!serviceRequestExists)
            {
                return BadRequest(new { message = "The associated service request does not exist." });
            }

            var proposal = new Proposal
            {
                Description = proposalDto.Description,
                BidAmount = proposalDto.BidAmount,
                ServiceRequestId = proposalDto.ServiceRequestId,
                SubmittedAt = DateTime.UtcNow,
                Status = ProposalStatus.Pending,
                CreatorId = userId
            };

            try
            {
                _context.Proposals.Add(proposal);
                await _context.SaveChangesAsync();

                var responseDto = new ProposalResponseDto
                {
                    Id = proposal.Id,
                    Description = proposal.Description,
                    BidAmount = proposal.BidAmount,
                    SubmittedAt = proposal.SubmittedAt,
                    Status = proposal.Status,
                    ServiceRequestId = proposal.ServiceRequestId,
                    CreatorId = proposal.CreatorId
                };

                return CreatedAtAction(nameof(GetProposal), new { id = proposal.Id }, responseDto);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { message = "Database error occurred while saving the proposal.", error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }

        // PUT: api/proposals/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProposal(int id, ProposalCreateDto proposalDto)
        {
            if (proposalDto == null )
            {
                return BadRequest(new { message = "Invalid proposal data." });
            }

            var proposal = await _context.Proposals.FindAsync(id);
            if (proposal == null)
            {
                return NotFound(new { message = "Proposal not found." });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (proposal.CreatorId != userId)
            {
                return new ObjectResult(new { message = "Authenticated user does not have access to modify proposal" })
                {
                StatusCode = StatusCodes.Status403Forbidden
                };
            }

            proposal.Description = proposalDto.Description;
            proposal.BidAmount = proposalDto.BidAmount;
            proposal.ServiceRequestId = proposalDto.ServiceRequestId;

            try
            {
                _context.Entry(proposal).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "The proposal was updated by another process. Please refresh and try again." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred while updating the proposal.", error = ex.Message });
            }
        }

        // DELETE: api/proposals/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProposal(int id)
        {
            try
            {
                var proposal = await _context.Proposals.FindAsync(id);
                if (proposal == null)
                {
                    return NotFound(new { message = "Proposal not found." });
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (proposal.CreatorId != userId)
                {
                    return Forbid();
                }

                _context.Proposals.Remove(proposal);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the proposal.", error = ex.Message });
            }
        }
    }
}
