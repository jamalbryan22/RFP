namespace RFP_APP.Server.Services
{
    using RFP_APP.Server.DTOs;
    using RFP_APP.Server.Models;
    using RFP_APP.Server.Repositories.Interfaces;
    using RFP_APP.Server.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using RFP_APP.Server.Models.Enums;

    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestRepository _repository;

        public ServiceRequestService(IServiceRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ServiceRequestResponseDto>> GetAllForAdminAsync()
        {
            var requests = await _repository.GetAllAsync();
            return requests.Select(MapToDto);
        }

        public async Task<IEnumerable<ServiceRequestResponseDto>> GetAllAsync()
        {
            var requests = await _repository.GetAllAsync();
            return requests.Select(MapToDto);
        }

        public async Task<IEnumerable<ServiceRequestResponseDto>> SearchAsync(
            string? query,
            string? type,
            string? city,
            string? state,
            decimal? minBudget,
            DateTime? deadline)
        {
            var requests = _repository.AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                var likePattern = $"%{query}%";
                requests = requests.Where(r =>
                    EF.Functions.Like(r.Title, likePattern) ||
                    EF.Functions.Like(r.Description, likePattern));
            }

            if (!string.IsNullOrEmpty(type) && Enum.TryParse<ServiceRequestType>(type, out var parsedType))
            {
                requests = requests.Where(r => r.RequestType == parsedType);
            }

            if (!string.IsNullOrEmpty(city))
            {
                requests = requests.Where(r =>
                    EF.Functions.Like(r.City, city));
            }

            if (!string.IsNullOrEmpty(state))
            {
                requests = requests.Where(r =>
                    EF.Functions.Like(r.State, state));
            }

            if (minBudget.HasValue)
            {
                requests = requests.Where(r => r.Budget >= minBudget.Value);
            }

            if (deadline.HasValue)
            {
                requests = requests.Where(r => r.Deadline <= deadline.Value);
            }

            var result = await requests.ToListAsync();
            return result.Select(MapToDto);
        }



        public async Task<IEnumerable<ServiceRequestResponseDto>> GetMyRequestsAsync(string userId)
        {
            var requests = await _repository.GetByUserIdAsync(userId);
            return requests.Select(MapToDto);
        }

        public async Task<ServiceRequestResponseDto?> GetByIdAsync(int id, string userId, bool isAdmin)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) return null;

            return MapToDto(request);
        }

        public async Task<ServiceRequestResponseDto> CreateAsync(ServiceRequestCreateDto dto, string userId)
        {
            var entity = new ServiceRequest
            {
                Title = dto.Title,
                Description = dto.Description,
                RequestType = dto.RequestType,
                StreetAddress = dto.StreetAddress,
                City = dto.City,
                State = dto.State,
                PostalCode = dto.PostalCode,
                Country = dto.Country,
                Budget = dto.Budget,
                CreatedAt = DateTime.UtcNow,
                Deadline = dto.Deadline,
                CreatorId = userId
            };

            await _repository.AddAsync(entity);
            return MapToDto(entity);
        }

        public async Task<bool> DeleteAsync(int id, string userId, bool isAdmin)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) return false;

            if (!isAdmin && request.CreatorId != userId)
                return false;

            await _repository.DeleteAsync(request);
            return true;
        }

        private static ServiceRequestResponseDto MapToDto(ServiceRequest sr)
        {
            return new ServiceRequestResponseDto
            {
                Id = sr.Id,
                Title = sr.Title,
                Description = sr.Description,
                RequestType = sr.RequestType.ToString(),
                StreetAddress = sr.StreetAddress,
                Status = sr.Status.ToString(),
                City = sr.City,
                State = sr.State,
                PostalCode = sr.PostalCode,
                Country = sr.Country,
                Budget = sr.Budget,
                CreatedAt = sr.CreatedAt,
                Deadline = sr.Deadline,
                CreatorId = sr.CreatorId,
                CreatorFullName = sr.Creator != null ? $"{sr.Creator.FirstName} {sr.Creator.LastName}" : null
            };
        }
    }
}
