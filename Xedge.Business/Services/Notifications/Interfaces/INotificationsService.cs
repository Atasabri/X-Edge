using Xedge.Infrastructure.DTOs.Notifications;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Notifications.Interfaces
{
    public interface INotificationsService
    {
        /// <summary>
        /// Get Current User Notifications Order By DateTime Desc (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<NotificationDTO>> GetUserNotificationsAsync(PagingParameters pagingParameters);
    }
}
