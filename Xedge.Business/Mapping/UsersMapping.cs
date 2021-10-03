using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Identity;
using Xedge.Infrastructure.DashboardViewModels.User;
using Xedge.Infrastructure.DTOs.Products;
using Xedge.Infrastructure.DTOs.User;
using Xedge.Infrastructure.DTOs.User.Address;
using Xedge.Infrastructure.DTOs.User.Driver;
using Xedge.Infrastructure.DTOs.User.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void UsersMapping()
        {
            CreateMap<User, ProfileDTO>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<User, DriverProfileDTO>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<User, DriverViewModel>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();

            CreateMap<ListingProductDTO, Favorites>()               
                .ForMember(dest => dest.Product_Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src))
                .ReverseMap();

            CreateMap<AddAddressDTO, Address>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<AddPaymentMethodDTO, PaymentMethod>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodDTO>().ReverseMap();
        }
        void DashboardUsersMapping()
        {
            CreateMap<AddNewAdminViewModel, User>()
                .ReverseMap();
            CreateMap<AdminViewModel, User>()
                .ReverseMap();
        }
    }
}
