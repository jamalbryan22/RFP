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
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestService _service;

        public ServiceRequestController(IServiceRequestService service)
        {
            _service = service;
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
    }
}
