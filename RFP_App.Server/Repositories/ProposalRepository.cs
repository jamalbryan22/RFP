using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.Repositories.Interfaces;
using RFP_APP.Server.Services.Interfaces;

namespace RFP_APP.Server.Repositories
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly ApplicationDbContext _context;

        public ProposalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proposal>> GetAllAsync()
        {
            return await _context.Proposals
                .Include(p => p.Creator)
                .Include(p => p.ServiceRequest)
                .ToListAsync();
        }

        public async Task<IEnumerable<Proposal>> GetByUserIdAsync(string userId)
        {
            return await _context.Proposals
                .Where(p => p.CreatorId == userId)
                .Include(p => p.Creator)
                .Include(p => p.ServiceRequest)
                .ToListAsync();
        }

        public async Task<Proposal?> GetByIdAsync(int id)
        {
            return await _context.Proposals
                .Include(p => p.Creator)
                .Include(p => p.ServiceRequest)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Proposal proposal)
        {
            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Proposal proposal)
        {
            _context.Proposals.Remove(proposal);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Proposal> Query()
        {
            return _context.Proposals.AsQueryable();
        }

        public async Task<Proposal?> GetByIdWithRequestAsync(int id)
        {
            return await _context.Proposals
                .Include(p => p.ServiceRequest)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Proposal>> GetByServiceRequestIdAsync(int requestId)
        {
            return await _context.Proposals
                .Where(p => p.ServiceRequestId == requestId)
                .Include(p => p.ServiceRequest)
                .Include(p => p.Creator)
                .ToListAsync();
        }
    }
}