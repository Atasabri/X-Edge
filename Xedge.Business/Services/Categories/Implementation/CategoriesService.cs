using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Categories.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Categories;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Categories.Implementation
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;

        public CategoriesService(IUnitOfWork unitofwork, IMapper mapper)
        {
            this._unitofwork = unitofwork;
            this._mapper = mapper;
        }

        public async Task<PagedResult<CategoryDTO>> GetCategoriesAsync(PagingParameters pagingParameters)
        {
            var categories = await _unitofwork.CategoriesRepository
                .GetElementsWithOrderAsync(Cat => true, pagingParameters, Cat => Cat.Id, OrderingType.Descending);

            var categoriesDTOs = categories.ToMappedPagedResult<Category, CategoryDTO>(_mapper);

            return categoriesDTOs;
        }

        public async Task<PagedResult<CategoryIncludeSubCategoriesDTO>> GetCategoriesIncludeSubCategoriesAsync(PagingParameters pagingParameters)
        {
            var categories = await _unitofwork.CategoriesRepository
                .GetElementsWithOrderAsync(Cat => true, pagingParameters, Cat => Cat.Id,
                OrderingType.Descending, nameof(Category.SubCategories));

            var categoriesDTOs = categories.ToMappedPagedResult<Category, CategoryIncludeSubCategoriesDTO>(_mapper);

            return categoriesDTOs;
        }

        public async Task<PagedResult<SubCategoryDTO>> GetSubCategoriesAsync(int catId, PagingParameters pagingParameters)
        {
            var subCategories = await _unitofwork.SubCategoriesRepository
                .GetElementsAsync(subCat => subCat.Category_Id == catId, pagingParameters);

            var subCategoriesDTOs = subCategories.ToMappedPagedResult<SubCategory, SubCategoryDTO>(_mapper);

            return subCategoriesDTOs;
        }
    }
}
