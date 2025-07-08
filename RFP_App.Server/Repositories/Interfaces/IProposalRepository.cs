using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.Repositories.Interfaces;
using RFP_APP.Server.Services.Interfaces;

namespace RFP_APP.Server.Repositories.Interfaces
{
    public interface IProposalRepository: IBaseRepository<Proposal>
    {
        Task<IEnumerable<Proposal>> GetByUserIdAsync(string userId);
        Task<Proposal?> GetByIdWithRequestAsync(int id);
        Task<List<Proposal>> GetByServiceRequestIdAsync(int requestId);
    }
}
