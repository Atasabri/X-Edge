using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Markets.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Markets;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Markets.Implementation
{
    public class MarketsService : IMarketsService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public MarketsService(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitofwork = unitofwork;
            this._mapper = mapper;
        }
        public async Task<PagedResult<MarketDTO>> GetMarketsAsync(PagingParameters pagingParameters)
        {
            var markets = await _unitofwork.MarketsRepository.GetElementsAsync(market => true, pagingParameters);

            var marketsDTOs = markets.ToMappedPagedResult<Market, MarketDTO>(_mapper);
            return marketsDTOs;
        }
    }
}
