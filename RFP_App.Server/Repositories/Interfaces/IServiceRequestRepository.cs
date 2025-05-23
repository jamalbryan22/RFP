using RFP_APP.Server.Models;

namespace RFP_APP.Server.Repositories.Interfaces
{
    public interface IServiceRequestRepository
    {
        Task<IEnumerable<ServiceRequest>> GetAllAsync();
        Task<IEnumerable<ServiceRequest>> GetByUserIdAsync(string userId);
        Task<ServiceRequest?> GetByIdAsync(int id);
        Task AddAsync(ServiceRequest request);
        Task UpdateAsync(ServiceRequest request);
        Task DeleteAsync(ServiceRequest request);
        IQueryable<ServiceRequest> AsQueryable();
    }
}
