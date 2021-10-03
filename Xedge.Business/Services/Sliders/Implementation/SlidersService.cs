﻿using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Sliders.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Sliders;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Sliders.Implementation
{
    public class SlidersService : ISlidersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SlidersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<PagedResult<SliderDTO>> GetSlidersAsync(PagingParameters pagingparameters)
        {
            var sliders = await _unitOfWork.SlidersRepository.GetElementsWithOrderAsync(slider => true
                               , pagingparameters
                               , slider => slider.Id
                               , OrderingType.Descending);

            var slidersDTOs = sliders.ToMappedPagedResult<Slider, SliderDTO>(_mapper);

            return slidersDTOs;
        }
    }
}
