using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Offers;
using Xedge.Infrastructure.DTOs.Offers;
using Xedge.Infrastructure.DTOs.Products;
using Xedge.Infrastructure.DTOs.User;
using Xedge.Infrastructure.DTOs.User.Address;
using Xedge.Infrastructure.DTOs.User.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void OffersMapping()
        {
            CreateMap<Offer, OfferDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ReverseMap();
        }

        void DashboardOffersMapping()
        {
            CreateMap<Offer, OfferViewModel>().ReverseMap();
            CreateMap<AddOfferViewModel, Offer>().ReverseMap();
            CreateMap<EditOfferViewModel, Offer>().ReverseMap();
        }
    }
}
