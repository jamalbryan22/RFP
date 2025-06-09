using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using RFP_APP.Server.DTOs;
using RFP_APP.Server.Models;
using RFP_APP.Server.Services.Interfaces;
using System.Security.Claims;
using RFP_APP.Server.Models.Enums;


namespace RFP_APP.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestService _service;
        private readonly IProposalService _proposalService;

        public ServiceRequestController(IServiceRequestService service, IProposalService proposalService)
        {
            _service = service;
            _proposalService = proposalService;
        }

        // GET: api/servicerequest (admin = all, user = theirs only)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequestResponseDto>>> GetRequests()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User!.IsInRole("Admin");

            var result = isAdmin
                ? await _service.GetAllForAdminAsync()
                : await _service.GetMyRequestsAsync(userId!);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchServiceRequests(
            [FromQuery] string? query,
            [FromQuery] string? type,
            [FromQuery] string? city,
            [FromQuery] string? state,
            [FromQuery] decimal? minBudget,
            [FromQuery] DateTime? deadline)
        {
            var result = await _service.SearchAsync(query, type, city, state, minBudget, deadline);
            return Ok(result);
        }



        // GET: api/servicerequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequestResponseDto>> GetRequestById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("Admin");

            var result = await _service.GetByIdAsync(id, userId!, isAdmin);

            if (result == null)
                return NotFound(new { message = "Service request not found or access denied." });

            return Ok(result);
        }

        // POST: api/servicerequest
        [HttpPost]
        public async Task<ActionResult<ServiceRequestResponseDto>> CreateRequest([FromBody] ServiceRequestCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var created = await _service.CreateAsync(dto, userId!);

            return CreatedAtAction(nameof(GetRequestById), new { id = created.Id }, created);
        }

        // DELETE: api/servicerequest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("Admin");

            var success = await _service.DeleteAsync(id, userId!, isAdmin);

            if (!success)
                return Forbid();

            return Ok(new { message = "Service request deleted successfully." });
        }

        // Return request types to front end 
        [HttpGet("request-types")]
        public IActionResult GetRequestTypes()
        {
            var values = Enum.GetValues(typeof(ServiceRequestType))
                .Cast<ServiceRequestType>()
                .Select(rt => new
                {
                    value = rt.ToString(),
                    label = Regex.Replace(rt.ToString(), "(\\B[A-Z])", " $1")
                });

            return Ok(values);
        }


        // GET: api/servicerequest/{id}/proposals
        // This endpoint returns all proposals for a specific service request
        [HttpGet("{id}/proposals")]
        public async Task<ActionResult<IEnumerable<ProposalResponseDto>>> GetProposalsForServiceRequest(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("Admin");

            var proposals = await _proposalService.GetByServiceRequestIdAsync(id, userId!, isAdmin);
            return Ok(proposals);
        }
    }
}
