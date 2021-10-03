using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Business.Mapping;
using Xedge.Business.Services.News.Interfaces;
using Xedge.Infrastructure.DTOs.News;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;

namespace Xedge.Business.Services.News.Implementation
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<PagedResult<NewsDTO>> GetNewsAsync(PagingParameters pagingparameters)
        {
            var news = await _unitOfWork.NewsRepository.GetElementsWithOrderAsync(news => true
                              , pagingparameters
                              , news => news.Id, OrderingType.Descending, nameof(Domain.Models.News.Images));

            var newsDTOs = news.ToMappedPagedResult<Domain.Models.News, NewsDTO>(_mapper);
            return newsDTOs;
        }

        public async Task<PagedResult<NewsDTO>> GetTodayNewsAsync(PagingParameters pagingparameters)
        {
            var news = await _unitOfWork.NewsRepository.GetElementsWithOrderAsync(news => news.Date.Date == DateTimeProvider.GetEgyptDateTime().Date
                              , pagingparameters
                              , news => news.Id, OrderingType.Descending, nameof(Domain.Models.News.Images));

            var newsDTOs = news.ToMappedPagedResult<Domain.Models.News, NewsDTO>(_mapper);
            return newsDTOs;
        }
    }
}
