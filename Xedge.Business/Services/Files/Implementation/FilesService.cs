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
            var files = await _unitOfWork.FilesRepository.GetElementsWithOrderAsync(news => true
                              , pagingparameters
                              , news => news.Id, OrderingType.Descending);

            var filesDTOs = files.ToMappedPagedResult<File, FileDTO>(_mapper);
            return filesDTOs;
        }
    }
}
