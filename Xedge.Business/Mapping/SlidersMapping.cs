using AutoMapper;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Sliders;
using Xedge.Infrastructure.DTOs.Sliders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void SlidersMapping()
        {
            CreateMap<Slider, SliderDTO>().ReverseMap();
        }

        void DashboardSlidersMapping()
        {
            CreateMap<Slider, SliderViewModel>().ReverseMap();
            CreateMap<AddSliderViewModel, Slider>().ReverseMap();
            CreateMap<EditSliderViewModel, Slider>().ReverseMap();
        }
    }
}
