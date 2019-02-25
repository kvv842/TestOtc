using NotificationService.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationService.Contracts
{
    public interface INotificationService
    {
        Task SendAsync(IEnumerable<INotification> notifications);
    }
}
