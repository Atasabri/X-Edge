using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Products;
using Xedge.Infrastructure.DTOs.Brand;
using Xedge.Infrastructure.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void ProductsMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedDescription).GetValue(src)))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(image => image.Path)))
                .ReverseMap();

            CreateMap<Product, ListingProductDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(image => image.Path)))
                .ReverseMap();
        }

        void DashboardProductsMapping()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.GetType().GetProperty(localizedName).GetValue(src.Brand)))
                .ForMember(dest => dest.MarketName, opt => opt.MapFrom(src => src.Market.GetType().GetProperty(localizedName).GetValue(src.Brand)))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.OfferName, opt => opt.MapFrom(src => src.Offer_Id.HasValue? src.Offer.Name : null))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(image => image.Path)))
                .ReverseMap();
            CreateMap<Product, ListingProductViewModel>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.GetType().GetProperty(localizedName).GetValue(src.Brand)))
                .ForMember(dest => dest.MarketName, opt => opt.MapFrom(src => src.Market.GetType().GetProperty(localizedName).GetValue(src.Brand)))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ReverseMap();
            CreateMap<AddProductViewModel, Product>().ReverseMap();
            CreateMap<EditProductViewModel, Product>().ReverseMap();
        }
    }
}
