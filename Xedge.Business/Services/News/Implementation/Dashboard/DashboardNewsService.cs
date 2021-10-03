using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xedge.Business.Mapping;
using Xedge.Business.Services.News.Interfaces.Dashboard;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.News;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Manage_Files;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;

namespace Xedge.Business.Services.News.Implementation.Dashboard
{
    public class DashboardNewsService : IDashboardNewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardNewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateNewsAsync(AddNewsViewModel addNewsViewModel)
        {
            var createState = new CreateState();
            var news = _mapper.Map<AddNewsViewModel, Domain.Models.News>(addNewsViewModel);
            news.Images = new List<NewsImages>();
            List<SavingFileData> savingFilesData = new List<SavingFileData>();
            Guid key = Guid.NewGuid();
            foreach (var photo in addNewsViewModel.Photos)
            {
                string path = "/Uploads/News/" + key + photo.FileName;
                news.Images.Add(new NewsImages { Path = path });
                var imageData = new SavingFileData()
                {
                    File = photo,
                    fileName = Path.GetFileName(path),
                    folderName = "News",
                    fileExtention = string.Empty
                };
                savingFilesData.Add(imageData);
            }
            await _unitOfWork.NewsRepository.CreateAsync(news);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                await _unitOfWork.SystemFilesRepository.SaveFilesAsync(savingFilesData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create News");
            return createState;
        }

        public async Task<ActionState> DeleteNewsAsync(int id)
        {
            var actionState = new ActionState();
            var news = await _unitOfWork.NewsRepository.FindElementAsync(News =>News.Id == id,
                             nameof(Domain.Models.News.Images));
            if (news == null)
            {
                actionState.ErrorMessages.Add("Can Not Find News !");
                return actionState;
            }
            var images = news.Images.Select(image => image.Path);
            _unitOfWork.NewsRepository.Delete(news);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                foreach (var imagePath in images)
                {
                    var imagedate = new FileBaseData()
                    {
                        fileName = Path.GetFileName(imagePath),
                        folderName = "News",
                        fileExtention = string.Empty
                    };
                    await _unitOfWork.SystemFilesRepository.DeleteFileAsync(imagedate);
                }
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete News");
            return actionState;
        }

        public async Task<ActionState> EditNewsAsync(EditNewsViewModel editNewsViewModel)
        {
            var actionState = new ActionState();
            var news = _mapper.Map<EditNewsViewModel, Domain.Models.News>(editNewsViewModel);
            news.Images = new List<NewsImages>();
            List<SavingFileData> savingFilesData = new List<SavingFileData>();
            Guid key = Guid.NewGuid();
            if (editNewsViewModel.Photos != null)
            {
                foreach (var photo in editNewsViewModel.Photos)
                {
                    string path = "/Uploads/News/" + key + photo.FileName;
                    news.Images.Add(new NewsImages { Path = path });
                    var imageData = new SavingFileData()
                    {
                        File = photo,
                        fileName = Path.GetFileName(path),
                        folderName = "News",
                        fileExtention = string.Empty
                    };
                    savingFilesData.Add(imageData);
                }
            }         
            _unitOfWork.NewsRepository.Update(news);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                await _unitOfWork.SystemFilesRepository.SaveFilesAsync(savingFilesData);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit News");
            return actionState;
        }

        public async Task<PagedResult<ListingNewsViewModel>> GetDashboardNewsAsync(PagingParameters pagingParameters)
        {
            var news = await _unitOfWork.NewsRepository.GetElementsWithOrderAsync(News => true,
           pagingParameters, News => News.Id, OrderingType.Descending);

            var newsViewModel = news.ToMappedPagedResult<Domain.Models.News, ListingNewsViewModel>(_mapper);

            return newsViewModel;
        }

        public async Task<NewsViewModel> GetNewsDetailsAsync(int Id)
        {
            var news = await _unitOfWork.NewsRepository.FindElementAsync(News => News.Id == Id, 
                    nameof(Domain.Models.News.Images));

            var newsViewModel = _mapper.Map<Domain.Models.News, NewsViewModel>(news);

            return newsViewModel;
        }
        public async Task<ActionState> DeleteNewsImageAsync(int newsid, string path)
        {
            var actionState = new ActionState();
            var newsImage = await _unitOfWork.NewsImagesRepository.FindElementAsync(image => image.News_Id == newsid && image.Path == path);
            _unitOfWork.NewsImagesRepository.Delete(newsImage);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                var imagedate = new FileBaseData()
                {
                    fileName = Path.GetFileName(path),
                    folderName = "News",
                    fileExtention = ""
                };
                await _unitOfWork.SystemFilesRepository.DeleteFileAsync(imagedate);

                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete News Image");
            return actionState;
        }
    }
}
