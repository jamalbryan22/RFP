using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.Repositories.Interfaces;
using RFP_APP.Server.Services.Interfaces;

namespace RFP_APP.Server.Repositories.Interfaces
{
    public interface IReviewRepository: IBaseRepository<Review>
    {
        Task<IEnumerable<Review>> GetByReviewerIdAsync(string reviewerId);
    }
}
