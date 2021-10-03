using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.PromoCodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void DashboardPromoCodesMapping()
        {
            CreateMap<PromoCode, PromoCodeViewModel>().ReverseMap();
            CreateMap<AddPromoCodeViewModel, PromoCode>().ReverseMap();
            CreateMap<EditPromoCodeViewModel, PromoCode>().ReverseMap();
        }
    }
}
