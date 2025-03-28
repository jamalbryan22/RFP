using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.DTOs;
using RFP_APP.Server.Models;
using System.Security.Claims;

namespace RFP_APP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/servicerequest
        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequestResponseDto>>> GetServiceRequests()
        {
            var requests = await _context.ServiceRequests
                .Select(sr => new ServiceRequestResponseDto
                {
                    Id = sr.Id,
                    Title = sr.Title,
                    Description = sr.Description,
                    RequestType = sr.RequestType.ToString(),
                    StreetAddress = sr.StreetAddress,
                    City = sr.City,
                    State = sr.State,
                    PostalCode = sr.PostalCode,
                    Country = sr.Country,
                    Budget = sr.Budget,
                    CreatedAt = sr.CreatedAt,
                    Deadline = sr.Deadline,
                    CreatorId = sr.CreatorId,
                    CreatorFullName = sr.Creator != null ? sr.Creator.FirstName + " " + sr.Creator.LastName : null
                })
                .ToListAsync();

            return Ok(requests);
        }

        // GET: api/servicerequests/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequestResponseDto>> GetServiceRequest(int id)
        {
            var serviceRequest = await _context.ServiceRequests
                .Where(sr => sr.Id == id)
                .Select(sr => new ServiceRequestResponseDto
                {
                    Id = sr.Id,
                    Title = sr.Title,
                    Description = sr.Description,
                    RequestType = sr.RequestType.ToString(),
                    StreetAddress = sr.StreetAddress,
                    City = sr.City,
                    State = sr.State,
                    PostalCode = sr.PostalCode,
                    Country = sr.Country,
                    Budget = sr.Budget,
                    CreatedAt = sr.CreatedAt,
                    Deadline = sr.Deadline,
                    CreatorId = sr.CreatorId,
                    CreatorFullName = sr.Creator != null ? sr.Creator.FirstName + " " + sr.Creator.LastName : null
                })
                .FirstOrDefaultAsync();

            if (serviceRequest == null)
            {
                return NotFound(new { message = "Service request not found." });
            }

            return Ok(serviceRequest);
        }


        // POST: api/servicerequests
        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> CreateServiceRequest(ServiceRequestCreateDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated." });
            }

            var serviceRequest = new ServiceRequest
            {
                Title = requestDto.Title,
                Description = requestDto.Description,
                RequestType = requestDto.RequestType,
                StreetAddress = requestDto.StreetAddress,
                City = requestDto.City,
                State = requestDto.State,
                PostalCode = requestDto.PostalCode,
                Country = requestDto.Country,
                Budget = requestDto.Budget,
                Deadline = requestDto.Deadline,
                CreatedAt = DateTime.UtcNow,
                CreatorId = userId
            };

            try
            {
                _context.ServiceRequests.Add(serviceRequest);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetServiceRequest), new { id = serviceRequest.Id }, serviceRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the service request.", error = ex.Message });
            }
        }

        // PUT: api/servicerequests/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceRequest(int id, ServiceRequestCreateDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound(new { message = "Service request not found." });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (serviceRequest.CreatorId != userId)
            {
                return Forbid();
            }

            serviceRequest.Title = requestDto.Title;
            serviceRequest.Description = requestDto.Description;
            serviceRequest.RequestType = requestDto.RequestType;
            serviceRequest.StreetAddress = requestDto.StreetAddress;
            serviceRequest.City = requestDto.City;
            serviceRequest.State = requestDto.State;
            serviceRequest.PostalCode = requestDto.PostalCode;
            serviceRequest.Country = requestDto.Country;
            serviceRequest.Budget = requestDto.Budget;
            serviceRequest.Deadline = requestDto.Deadline;

            _context.Entry(serviceRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the service request.", error = ex.Message });
            }
        }

        // DELETE: api/servicerequests/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRequest(int id)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound(new { message = "Service request not found." });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (serviceRequest.CreatorId != userId)
            {
                return Forbid();
            }

            _context.ServiceRequests.Remove(serviceRequest);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the service request.", error = ex.Message });
            }
        }
    }
}
