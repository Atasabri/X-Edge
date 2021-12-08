using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Files.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Files;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;

namespace Xedge.Business.Services.Files.Implementation
{
    public class FilesService : IFilesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FilesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<PagedResult<FileDTO>> GetFilesAsync(PagingParameters pagingparameters)
        {
            var files = await _unitOfWork.FilesRepository.GetElementsWithOrderAsync(file => true
                              , pagingparameters
                              , file => file.Id, OrderingType.Descending);

            var filesDTOs = files.ToMappedPagedResult<File, FileDTO>(_mapper);
            return filesDTOs;
        }

        public async Task<PagedResult<FileDTO>> GetFilesUsingCategoryAsync(int catId, PagingParameters pagingparameters)
        {
            var files = await _unitOfWork.FilesRepository.GetElementsWithOrderAsync(file => file.Category_Id == catId
                              , pagingparameters
                              , file => file.Id, OrderingType.Descending);

            var filesDTOs = files.ToMappedPagedResult<File, FileDTO>(_mapper);
            return filesDTOs;
        }

        public async Task<PagedResult<FileCategoryDTO>> GetFilesCategoriesAsync(PagingParameters pagingparameters)
        {
            var files = await _unitOfWork.FilesCategoryRepository.GetElementsWithOrderAsync(category => true
                              , pagingparameters
                              , category => category.Id, OrderingType.Descending);

            var filesDTOs = files.ToMappedPagedResult<FileCategory, FileCategoryDTO>(_mapper);
            return filesDTOs;
        }
    }
}
