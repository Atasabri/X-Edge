using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Notifications.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Notifications;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Notifications.Implementation
{
    public class NotificationsService : INotificationsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<PagedResult<NotificationDTO>> GetUserNotificationsAsync(PagingParameters pagingParameters)
        {
            var userId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            
            var notifications = await _unitOfWork.NotificationsRepository.GetElementsWithOrderAsync(notification => notification.User_Id == userId,
                pagingParameters,
                notification => notification.DateTime, OrderingType.Descending);

            var notificationsDTOs = notifications.ToMappedPagedResult<Notification, NotificationDTO>(_mapper);

            return notificationsDTOs;
        }
    }
}
