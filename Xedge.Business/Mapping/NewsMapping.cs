using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.News;
using Xedge.Infrastructure.DTOs.News;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void NewsMapping()
        {
            CreateMap<News, NewsDTO>()
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedTitle).GetValue(src)))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedDescription).GetValue(src)))
                    .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(image => image.Path)))
                    .ReverseMap();
        }

        void DashboardNewsMapping()
        {
            CreateMap<News, ListingNewsViewModel>()
                    .ReverseMap();
            CreateMap<News, NewsViewModel>()
                    .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(image => image.Path)))
                    .ReverseMap();
            CreateMap<AddNewsViewModel, News>()
                    .ReverseMap();
            CreateMap<EditNewsViewModel, News>()
                    .ReverseMap();
        }
    }
}
