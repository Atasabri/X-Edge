using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Markets;
using Xedge.Infrastructure.DTOs.Markets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void MarketsMapping()
        {
            CreateMap<Market, MarketDTO>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                    .ReverseMap();
        }

        void DashboardMarketsMapping()
        {
            CreateMap<Market, MarketViewModel>().ReverseMap();
            CreateMap<AddMarketViewModel, Market>().ReverseMap();
            CreateMap<EditMarketViewModel, Market>().ReverseMap();
        }
    }
}
