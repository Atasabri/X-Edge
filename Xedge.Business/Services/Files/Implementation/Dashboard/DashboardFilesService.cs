using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Files.Interfaces.Dashboard;
using Xedge.Infrastructure.DashboardViewModels.Files;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Manage_Files;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;

namespace Xedge.Business.Services.Files.Implementation.Dashboard
{
    public class DashboardFilesService : IDashboardFilesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardFilesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateFileAsync(AddFileViewModel addFileViewModel)
        {
            var createState = new CreateState();
            var file = _mapper.Map<AddFileViewModel, Domain.Models.File>(addFileViewModel);
            file.SizeinMB = Convert.ToDouble((double)addFileViewModel.File.Length / (double)(1024 * 1000));
            var extention = Path.GetExtension(addFileViewModel.File.FileName);
            file.Extention = extention;
            await _unitOfWork.FilesRepository.CreateAsync(file);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                var imageData = new SavingFileData()
                {
                    File = addFileViewModel.File,
                    fileName = file.Id.ToString(),
                    folderName = "Files",
                    fileExtention = extention
                };
                await _unitOfWork.SystemFilesRepository.SaveFileAsync(imageData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create File");
            return createState;
        }

        public async Task<ActionState> DeleteFileAsync(int id)
        {
            var actionState = new ActionState();
            var file = await _unitOfWork.FilesRepository.FindByIdAsync(id);
            if (file == null)
            {
                actionState.ErrorMessages.Add("Can Not Find File !");
                return actionState;
            }
            var extention = file.Extention;
            _unitOfWork.FilesRepository.Delete(file);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "Files",
                    fileExtention = extention
                };
                await _unitOfWork.SystemFilesRepository.DeleteFileAsync(imagedate);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete File");
            return actionState;
        }

        public async Task<ActionState> EditFileAsync(EditFileViewModel editFileViewModel)
        {
            var actionState = new ActionState();
            var file = _mapper.Map<EditFileViewModel, Domain.Models.File>(editFileViewModel);

            SavingFileData imageData = null;
            
            if (editFileViewModel.File != null)
            {
                file.SizeinMB = Convert.ToDouble((double)editFileViewModel.File.Length / (double)(1024 * 1000));
                var extention = Path.GetExtension(editFileViewModel.File.FileName);
                file.Extention = extention;

                imageData = new SavingFileData()
                {
                    File = editFileViewModel.File,
                    fileName = file.Id.ToString(),
                    folderName = "Files",
                    fileExtention = Path.GetExtension(editFileViewModel.File.FileName)
                };
            }
        
            _unitOfWork.FilesRepository.Update(file);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                if (imageData != null)
                {
                    await _unitOfWork.SystemFilesRepository.SaveFileAsync(imageData);
                }
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit File");
            return actionState;
        }

        public async Task<PagedResult<FileViewModel>> GetDashboardFilesAsync(PagingParameters pagingParameters)
        {
            var files = await _unitOfWork.FilesRepository.GetElementsWithOrderAsync(File => true,
                      pagingParameters, File => File.Id, OrderingType.Descending);

            var filesViewModel = files.ToMappedPagedResult<Domain.Models.File, FileViewModel>(_mapper);

            return filesViewModel;
        }

        public async Task<FileViewModel> GetFileDetailsAsync(int Id)
        {
            var file = await _unitOfWork.FilesRepository.FindByIdAsync(Id);

            var fileViewModel = _mapper.Map<Domain.Models.File, FileViewModel>(file);

            return fileViewModel;
        }
    }
}
