using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Categories;
using Xedge.Infrastructure.DashboardViewModels.Categories.Categories;
using Xedge.Infrastructure.DashboardViewModels.Categories.SubCategories;
using Xedge.Infrastructure.DTOs.Categories;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        public void CategoriesMapping()
        {

            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ReverseMap();

            CreateMap<Category, CategoryIncludeSubCategoriesDTO>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                 .ReverseMap();

            CreateMap<SubCategory, SubCategoryDTO>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                .ReverseMap();
        }

        public void DashboardCategoriesMapping()
        {
            CreateMap<AddCategoryViewModel, Category>().ReverseMap();
            CreateMap<EditCategoryViewModel, Category>().ReverseMap();
            CreateMap<Category, CategoryViewModel>()
                .ReverseMap();

            CreateMap<AddSubCategoryViewModel, SubCategory>().ReverseMap();
            CreateMap<EditSubCategoryViewModel, SubCategory>().ReverseMap();
            CreateMap<SubCategory, SubCategoryViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ReverseMap();
        }
    }
}
