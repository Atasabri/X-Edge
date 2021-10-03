using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {

        void DashboardSettingsMapping()
        {
            CreateMap<Settings, SettingsKeyValueViewModel>().ReverseMap();
        }
    }
}
