using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Videos.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Videos;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;

namespace Xedge.Business.Services.Videos.Implementation
{
    public class VideosService : IVideosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VideosService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PagedResult<VideoDTO>> GetVideosAsync(PagingParameters pagingparameters)
        {
            var videos = await _unitOfWork.VideosRepository.GetElementsWithOrderAsync(news => true
                                          , pagingparameters
                                          , news => news.Id, OrderingType.Descending);

            var videosDTOs = videos.ToMappedPagedResult<Video, VideoDTO>(_mapper);
            return videosDTOs;
        }
    }
}
