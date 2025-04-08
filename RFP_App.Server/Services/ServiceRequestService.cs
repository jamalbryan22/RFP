namespace RFP_APP.Server.Services
{
    using RFP_APP.Server.DTOs;
    using RFP_APP.Server.Models;
    using RFP_APP.Server.Repositories.Interfaces;
    using RFP_APP.Server.Services.Interfaces;

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

        public async Task<IEnumerable<ServiceRequestResponseDto>> GetMyRequestsAsync(string userId)
        {
            var requests = await _repository.GetByUserIdAsync(userId);
            return requests.Select(MapToDto);
        }

        public async Task<ServiceRequestResponseDto?> GetByIdAsync(int id, string userId, bool isAdmin)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) return null;

            if (!isAdmin && request.CreatorId != userId)
                return null;

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
