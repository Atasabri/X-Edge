using Xedge.Business.Services.Notifications.Interfaces;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.APIs
{
    public class NotificationsController : AuthorizedAPIController
    {
        private readonly INotificationsService _notificationsservice;

        public NotificationsController(INotificationsService notificationsservice)
        {
            this._notificationsservice = notificationsservice;
        }

        [HttpGet("GetUserNotifications")]
        public async Task<IActionResult> GetUserNotifications([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _notificationsservice.GetUserNotificationsAsync(pagingParameters));
        }
    }
}
