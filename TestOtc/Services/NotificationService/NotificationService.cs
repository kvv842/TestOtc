using NotificationService.Contracts;
using NotificationService.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationService
{
    public class NotificationService: INotificationService
    {
        public async Task SendAsync(IEnumerable<INotification> notifications)
        {
            // TODO данная реализация просто пишит к себе в БД уведомления, отвечает ок, потом асинхронно рассылает их.

            await Task.CompletedTask;
        }
    }
}
