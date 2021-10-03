using Xedge.Domain.Models;
using Xedge.Infrastructure.NotificationsHelpers.MobileNotificationModels;
using Xedge.Infrastructure.NotificationsHelpers;
using Xedge.Repo.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Repo.Repositories.Interfaces.Notifications
{
    public interface INotificationsRepository : IGenericRepository<Notification>
    {
        /// <summary>
        /// Sending Notification To All Open Connections Asynchronous
        /// </summary>
        /// <param name="webNotificationState"></param>
        /// <returns></returns>
        Task WebNotifyToAllAsync(WebNotificationState webNotificationState);
        /// <summary>
        /// Sending Notification To Mobile Device Using Device FCM Asynchronous
        /// </summary>
        /// <param name="deviceNotifyState"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> NotifyDevicesAsync(DeviceNotifyState deviceNotifyState);
        /// <summary>
        /// Sending Notification To Mobile Device Using Topic Asynchronous
        /// </summary>
        /// <param name="topicNotifyState"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> NotifyTopicAsync(TopicNotifyState topicNotifyState);
    }
}
