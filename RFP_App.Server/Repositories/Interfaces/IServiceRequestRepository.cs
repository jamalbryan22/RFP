using RFP_APP.Server.Models;
using RFP_APP.Server.Repositories.Interfaces;

namespace RFP_APP.Server.Repositories.Interfaces
{
    public interface IServiceRequestRepository: IBaseRepository<ServiceRequest>
    {
        Task<IEnumerable<ServiceRequest>> GetByUserIdAsync(string userId);
    }
}
