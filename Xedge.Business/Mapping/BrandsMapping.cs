using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Brand;
using Xedge.Infrastructure.DTOs.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void BrandsMapping()
        {
            CreateMap<Brand, BrandDTO>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                    .ReverseMap();
        }
        void DashboardBrandsMapping()
        {
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<AddBrandViewModel, Brand>().ReverseMap();
            CreateMap<EditBrandViewModel, Brand>().ReverseMap();
        }
    }
}
