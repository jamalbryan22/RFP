using RFP_APP.Server.DTOs;
using RFP_APP.Server.Models;

namespace RFP_APP.Server.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetMyNotificationsAsync(string userId);
        Task<NotificationDto?> CreateAsync(CreateNotificationDto dto);
        Task<bool> DeleteAsync(int id, string userId, bool isAdmin);
    }
}
