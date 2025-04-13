using RFP_APP.Server.DTOs;
using RFP_APP.Server.Models;
using RFP_APP.Server.Repositories.Interfaces;
using RFP_APP.Server.Services.Interfaces;

namespace RFP_APP.Server.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NotificationDto>> GetMyNotificationsAsync(string userId)
        {
            var notifications = await _repository.GetByRecipientIdAsync(userId);
            return notifications.Select(MapToDto);
        }

        public async Task<NotificationDto?> CreateAsync(CreateNotificationDto dto)
        {
            var notification = new Notification
            {
                Message = dto.Message,
                RecipientId = dto.RecipientId,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(notification);
            return MapToDto(notification);
        }

        public async Task<bool> DeleteAsync(int id, string userId, bool isAdmin)
        {
            var notification = await _repository.GetByIdAsync(id);
            if (notification == null || (!isAdmin && notification.RecipientId != userId))
                return false;

            await _repository.DeleteAsync(notification);
            return true;
        }

        private NotificationDto MapToDto(Notification n)
        {
            return new NotificationDto
            {
                Id = n.Id,
                Message = n.Message,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt
            };
        }
    }
}