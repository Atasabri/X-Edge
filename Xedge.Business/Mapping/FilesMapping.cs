using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Files;
using Xedge.Infrastructure.DashboardViewModels.Files_Category.Files;
using Xedge.Infrastructure.DTOs.Files;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void FilesMapping()
        {
            CreateMap<File, FileDTO>()
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                   .ReverseMap();

            CreateMap<FileCategory, FileCategoryDTO>()
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GetType().GetProperty(localizedName).GetValue(src)))
                   .ReverseMap();
        }

        void DashboardFilesMapping()
        {
            CreateMap<File, FileViewModel>()
                    .ReverseMap();
            CreateMap<AddFileViewModel, File>()
                    .ReverseMap();
            CreateMap<EditFileViewModel, File>()
                    .ReverseMap();

            // Mapping FileCategories View Models
            CreateMap<FileCategory, FileCategoryViewModel>()
                   .ReverseMap();
            CreateMap<AddFileCategoryViewModel, FileCategory>()
                    .ReverseMap();
            CreateMap<EditFileCategoryViewModel, FileCategory>()
                    .ReverseMap();
        }
    }
}
