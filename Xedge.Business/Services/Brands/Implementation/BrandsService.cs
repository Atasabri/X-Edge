using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Brands.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Brand;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Brands.Implementation
{
    public class BrandsService : IBrandsService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public BrandsService(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitofwork = unitofwork;
            this._mapper = mapper;
        }
        public async Task<PagedResult<BrandDTO>> GetBrandsAsync(PagingParameters pagingParameters)
        {
            var brands = await _unitofwork.BrandsRepository.GetElementsAsync(brand => true, pagingParameters);

            var brandsDTOs = brands.ToMappedPagedResult<Brand, BrandDTO>(_mapper);
            return brandsDTOs;
        }
    }
}
