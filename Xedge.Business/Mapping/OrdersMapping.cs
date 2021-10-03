using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Orders;
using Xedge.Infrastructure.DTOs.Orders;
using Xedge.Infrastructure.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void OrdersMapping()
        {
            CreateMap<AddOrderDetailsDTO, OrderDetails>().ReverseMap();
            CreateMap<AddOrderDTO, Order>().ReverseMap();

            CreateMap<Order, ListingOrderDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver.FullName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.DriverPhone, opt => opt.MapFrom(src => src.Driver.PhoneNumber))
                .ReverseMap();

            CreateMap<OrderStatus, OrderStatusDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetType().GetProperty(localizedName).GetValue(src.Status)))
                .ReverseMap();

            CreateMap<OrderDetails, OrderDetailsDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.GetType().GetProperty(localizedName).GetValue(src.Product)))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Product.Images.Select(image => image.Path)))
                .ReverseMap();
        }

        void DashboardOrdersMapping()
        {
            CreateMap<Order, OrderViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName))
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => src.Driver.FullName))
            .ForMember(dest => dest.DriverPhone, opt => opt.MapFrom(src => src.Driver.PhoneNumber))
            .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.UserPhone, opt => opt.MapFrom(src => src.User.PhoneNumber))
            .ReverseMap();
            CreateMap<Order, ListingOrderViewModel>()
                .ReverseMap();

            CreateMap<OrderDetails, OrderDetailsViewModel>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
               .ReverseMap();
            CreateMap<OrderStatus, OrderStatusesViewModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
                .ReverseMap();
            CreateMap<AddOrderStatusViewModel, OrderStatus>().ReverseMap();
            CreateMap<Statuses, StatusesViewModel>().ReverseMap();
        }
    }
}
