using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Videos;
using Xedge.Infrastructure.DTOs.Videos;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void VideosMapping()
        {
            CreateMap<Video, VideoDTO>()
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedTitle).GetValue(src)))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedDescription).GetValue(src)))
                    .ReverseMap();
        }

        void DashboardVideosMapping()
        {
            CreateMap<Video, ListingVideoViewModel>()
                    .ReverseMap();
            CreateMap<Video, VideoViewModel>()
                    .ReverseMap();
            CreateMap<AddVideoViewModel, Video>()
                    .ReverseMap();
            CreateMap<EditVideoViewModel, Video>()
                    .ReverseMap();
        }
    }
}
