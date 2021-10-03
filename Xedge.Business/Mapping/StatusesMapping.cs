using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Statuses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void DashboardStatusesMapping()
        {
            CreateMap<Statuses, StatusViewModel>().ReverseMap();
            CreateMap<AddStatusViewModel, Statuses>().ReverseMap();
            CreateMap<EditStatusViewModel, Statuses>().ReverseMap();
        }
    }
}
