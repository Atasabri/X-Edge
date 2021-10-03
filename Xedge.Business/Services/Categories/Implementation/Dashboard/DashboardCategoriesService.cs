﻿using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Categories.Interfaces.Dashboard;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Categories;
using Xedge.Infrastructure.DashboardViewModels.Categories.Categories;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Manage_Files;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Categories.Implementation.Dashboard
{
    public class DashboardCategoriesService : IDashboardCategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardCategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateCategoryAsync(AddCategoryViewModel addCategoryViewModel)
        {
            var createState = new CreateState();
            var category = _mapper.Map<AddCategoryViewModel, Category>(addCategoryViewModel);

            await _unitOfWork.CategoriesRepository.CreateAsync(category);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                // Adding Category Photo
                var imageData = new SavingFileData()
                {
                    File = addCategoryViewModel.Photo,
                    fileName = category.Id.ToString(),
                    folderName = "Categories"
                };
                await _unitOfWork.SystemFilesRepository.SaveFileAsync(imageData);
                // Adding Category Banner
                var bannerData = new SavingFileData()
                {
                    File = addCategoryViewModel.Banner,
                    fileName = category.Id.ToString(),
                    folderName = "Categories/Banners"
                };
                await _unitOfWork.SystemFilesRepository.SaveFileAsync(bannerData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Category");
            return createState;
        }

        public async Task<ActionState> DeleteCategoryAsync(int id)
        {
            var actionState = new ActionState();
            var category = await _unitOfWork.CategoriesRepository.FindByIdAsync(id);
            if (await GetCategoryDetailsAsync(category.Id) == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Category !");
                return actionState;
            }
            _unitOfWork.CategoriesRepository.Delete(category);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                // Delete Category Photo
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "Categories"
                };
                await _unitOfWork.SystemFilesRepository.DeleteFileAsync(imagedate);
                // Delete Category Banner
                var bannerdate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "Categories/Banners"
                };
                await _unitOfWork.SystemFilesRepository.DeleteFileAsync(bannerdate);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Category");
            return actionState;
        }

        public async Task<ActionState> EditCategoryAsync(EditCategoryViewModel editCategoryViewModel)
        {
            var actionState = new ActionState();
            var category = _mapper.Map<EditCategoryViewModel, Category>(editCategoryViewModel);
            _unitOfWork.CategoriesRepository.Update(category);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                // Replace Category Photo If Photo Edited
                if (editCategoryViewModel.Photo != null)
                {
                    var imageData = new SavingFileData()
                    {
                        File = editCategoryViewModel.Photo,
                        fileName = category.Id.ToString(),
                        folderName = "Categories"
                    };
                    await _unitOfWork.SystemFilesRepository.SaveFileAsync(imageData);
                }
                // Replace Category Banner If Banner Edited
                if (editCategoryViewModel.Banner != null)
                {
                    var bannerData = new SavingFileData()
                    {
                        File = editCategoryViewModel.Banner,
                        fileName = category.Id.ToString(),
                        folderName = "Categories/Banners"
                    };
                    await _unitOfWork.SystemFilesRepository.SaveFileAsync(bannerData);
                }
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Category");
            return actionState;
        }

        public async Task<CategoryViewModel> GetCategoryDetailsAsync(int Id)
        {
            var category = await _unitOfWork.CategoriesRepository.FindElementAsync(cat => cat.Id == Id);

            var categoryViewModel = _mapper.Map<Category, CategoryViewModel>(category);

            return categoryViewModel;
        }

        public async Task<PagedResult<CategoryViewModel>> GetDashboardCategoriesAsync(PagingParameters pagingParameters)
        {
            var categories = await _unitOfWork.CategoriesRepository.GetElementsWithOrderAsync(cat => true,
                       pagingParameters, cat => cat.Id, OrderingType.Descending);

            var pagedCategoriesViewModel = categories.ToMappedPagedResult<Category, CategoryViewModel>(_mapper);

            return pagedCategoriesViewModel;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoriesRepository.GetElementsAsync(mainCat => true);

            var categoriesViewModel = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);

            return categoriesViewModel;
        }
    }
}
