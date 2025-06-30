using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RFP_APP.Server.DTOs;
using RFP_APP.Server.Services.Interfaces;
using System.Security.Claims;

namespace RFP_APP.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalService _proposalService;

        public ProposalController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }

        // GET: api/proposal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProposalResponseDto>>> GetProposals()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("Admin");

            var proposals = isAdmin
                ? await _proposalService.GetAllForAdminAsync()
                : await _proposalService.GetMyProposalsAsync(userId!);

            return Ok(proposals);
        }

        // GET: api/proposal/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProposalResponseDto>> GetProposalById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("Admin");

            var proposal = await _proposalService.GetByIdAsync(id, userId!, isAdmin);
            if (proposal == null)
                return NotFound(new { message = "Proposal not found or access denied." });

            return Ok(proposal);
        }

        // POST: api/proposal
        [HttpPost]
        public async Task<ActionResult<ProposalResponseDto>> CreateProposal([FromBody] ProposalCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var created = await _proposalService.CreateAsync(dto, userId!);

            return CreatedAtAction(nameof(GetProposalById), new { id = created.Id }, created);
        }

        // DELETE: api/proposal/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProposal(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("Admin");

            var success = await _proposalService.DeleteAsync(id, userId!, isAdmin);
            if (!success)
                return Forbid();

            return Ok(new { message = "Proposal deleted successfully." });
        }

        // PUT: api/proposal/{id}/accept
        [HttpPut("{id}/accept")]
        public async Task<IActionResult> AcceptProposal(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await _proposalService.UpdateStatusAsync(id, userId!, ProposalStatus.Accepted);
            return success ? Ok(new { message = "Proposal accepted." }) : Forbid();
        }

        // PUT: api/proposal/{id}/reject
        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectProposal(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await _proposalService.UpdateStatusAsync(id, userId!, ProposalStatus.Rejected);
            return success ? Ok(new { message = "Proposal rejected." }) : Forbid();
        }

    }
}
