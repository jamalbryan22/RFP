using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.Repositories.Interfaces;
using RFP_APP.Server.Services.Interfaces;

namespace RFP_APP.Server.Repositories.Interfaces
{
    public interface IProposalRepository
    {
        Task<IEnumerable<Proposal>> GetAllAsync();
        Task<IEnumerable<Proposal>> GetByUserIdAsync(string userId);
        Task<Proposal?> GetByIdAsync(int id);
        Task AddAsync(Proposal proposal);
        Task DeleteAsync(Proposal proposal);
        IQueryable<Proposal> Query();
        Task<Proposal?> GetByIdWithRequestAsync(int id);
        Task<List<Proposal>> GetByServiceRequestIdAsync(int requestId);
        Task UpdateAsync(Proposal proposal);

    }
}
