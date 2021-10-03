using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Videos.Interfaces.Dashboard;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Videos;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Manage_Files;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;

namespace Xedge.Business.Services.Videos.Implementation.Dashboard
{
    public class DashboardVideosService : IDashboardVideosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardVideosService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateVideoAsync(AddVideoViewModel addVideoViewModel)
        {
            var createState = new CreateState();
            var video = _mapper.Map<AddVideoViewModel, Video>(addVideoViewModel);

            await _unitOfWork.VideosRepository.CreateAsync(video);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                var imageData = new SavingFileData()
                {
                    File = addVideoViewModel.Video,
                    fileName = video.Id.ToString(),
                    folderName = "Videos",
                    fileExtention = ".mp4"
                };
                await _unitOfWork.SystemFilesRepository.SaveFileAsync(imageData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Video");
            return createState;
        }

        public async Task<ActionState> DeleteVideoAsync(int id)
        {
            var actionState = new ActionState();
            var video = await _unitOfWork.VideosRepository.FindByIdAsync(id);
            if (video == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Video !");
                return actionState;
            }
            _unitOfWork.VideosRepository.Delete(video);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "Videos",
                    fileExtention = ".mp4"
                };
                await _unitOfWork.SystemFilesRepository.DeleteFileAsync(imagedate);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Video");
            return actionState;
        }

        public async Task<ActionState> EditVideoAsync(EditVideoViewModel editVideoViewModel)
        {
            var actionState = new ActionState();
            var video = _mapper.Map<EditVideoViewModel, Video>(editVideoViewModel);
            _unitOfWork.VideosRepository.Update(video);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                if (editVideoViewModel.Video != null)
                {
                    var imageData = new SavingFileData()
                    {
                        File = editVideoViewModel.Video,
                        fileName = video.Id.ToString(),
                        folderName = "Videos",
                        fileExtention = ".mp4"
                    };
                    await _unitOfWork.SystemFilesRepository.SaveFileAsync(imageData);
                }
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Video");
            return actionState;
        }

        public async Task<PagedResult<ListingVideoViewModel>> GetDashboardVideosAsync(PagingParameters pagingParameters)
        {
            var videos = await _unitOfWork.VideosRepository.GetElementsWithOrderAsync(Video => true,
           pagingParameters, Video => Video.Id, OrderingType.Descending);

            var videosViewModel = videos.ToMappedPagedResult<Video, ListingVideoViewModel>(_mapper);

            return videosViewModel;
        }

        public async Task<VideoViewModel> GetVideoDetailsAsync(int Id)
        {
            var video = await _unitOfWork.VideosRepository.FindByIdAsync(Id);

            var videoViewModel = _mapper.Map<Video, VideoViewModel>(video);

            return videoViewModel;
        }
    }
}
