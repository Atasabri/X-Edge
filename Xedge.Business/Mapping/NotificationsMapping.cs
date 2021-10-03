using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Notifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void NotificationsMapping()
        {
            CreateMap<Notification, NotificationDTO>().ReverseMap();
        }
    }
}
