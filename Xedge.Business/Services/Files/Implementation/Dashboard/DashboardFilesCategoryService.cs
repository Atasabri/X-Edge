using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Files.Interfaces.Dashboard;
using Xedge.Infrastructure.DashboardViewModels.Files_Category.Files;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;

namespace Xedge.Business.Services.Files.Implementation.Dashboard
{
    public class DashboardFilesCategoryService : IDashboardFilesCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardFilesCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateFileCategoryAsync(AddFileCategoryViewModel addFileCategoryViewModel)
        {
            var createState = new CreateState();
            var fileCategory = _mapper.Map<AddFileCategoryViewModel, Domain.Models.FileCategory>(addFileCategoryViewModel);
            await _unitOfWork.FilesCategoryRepository.CreateAsync(fileCategory);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create File Category");
            return createState;
        }

        public async Task<ActionState> DeleteFileCategoryAsync(int id)
        {
            var actionState = new ActionState();
            var fileCategory = await _unitOfWork.FilesCategoryRepository.FindByIdAsync(id);
            if (fileCategory == null)
            {
                actionState.ErrorMessages.Add("Can Not Find File Category !");
                return actionState;
            }
            _unitOfWork.FilesCategoryRepository.Delete(fileCategory);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete File Category");
            return actionState;
        }

        public async Task<ActionState> EditFileCategoryAsync(EditFileCategoryViewModel editFileCategoryViewModel)
        {
            var actionState = new ActionState();
            var fileCategory = _mapper.Map<EditFileCategoryViewModel, Domain.Models.FileCategory>(editFileCategoryViewModel);

            _unitOfWork.FilesCategoryRepository.Update(fileCategory);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit File Category");
            return actionState;
        }

        public async Task<IEnumerable<FileCategoryViewModel>> GetAllDashboardFilesCategoriesAsync()
        {
            var filesCategories = await _unitOfWork.FilesCategoryRepository.GetElementsAsync(fileCategory => true);

            var filesCategoryViewModel = _mapper.Map<IEnumerable<Xedge.Domain.Models.FileCategory>, IEnumerable<FileCategoryViewModel>>(filesCategories);

            return filesCategoryViewModel;
        }

        public async Task<PagedResult<FileCategoryViewModel>> GetDashboardFilesCategoriesAsync(PagingParameters pagingParameters)
        {
            var filesCategories = await _unitOfWork.FilesCategoryRepository.GetElementsWithOrderAsync(fileCategory => true,
                      pagingParameters, fileCategory => fileCategory.Id, OrderingType.Descending);

            var filesCategoryViewModel = filesCategories.ToMappedPagedResult<Domain.Models.FileCategory, FileCategoryViewModel>(_mapper);

            return filesCategoryViewModel;
        }

        public async Task<FileCategoryViewModel> GetFileCategoryDetailsAsync(int Id)
        {
            var fileCategory = await _unitOfWork.FilesCategoryRepository.FindByIdAsync(Id);

            var fileCategoryViewModel = _mapper.Map<Domain.Models.FileCategory, FileCategoryViewModel>(fileCategory);

            return fileCategoryViewModel;
        }
    }
}
