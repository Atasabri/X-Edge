using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Offers.Interfaces.Dashboard;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Offers;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Manage_Files;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Offers.Implementation.Dashboard
{
    public class DashboardOffersService : IDashboardOffersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardOffersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateOfferAsync(AddOfferViewModel addOfferViewModel)
        {
            var createState = new CreateState();
            var offer = _mapper.Map<AddOfferViewModel, Offer>(addOfferViewModel);

            await _unitOfWork.OffersRepository.CreateAsync(offer);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                var imageData = new SavingFileData()
                {
                    File = addOfferViewModel.Photo,
                    fileName = offer.Id.ToString(),
                    folderName = "Offers"
                };
                await _unitOfWork.SystemFilesRepository.SaveFileAsync(imageData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Offer");
            return createState;
        }

        public async Task<ActionState> DeleteOfferAsync(int id)
        {
            var actionState = new ActionState();
            var offer = await _unitOfWork.OffersRepository.FindByIdAsync(id);
            if (offer == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Offer !");
                return actionState;
            }
            if (offer.Id == Constants.XedgeOfferId)
            {
                actionState.ErrorMessages.Add("Can Not Delete X-Edge Offer !");
                return actionState;
            }
            _unitOfWork.OffersRepository.Delete(offer);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "Offers"
                };
                await _unitOfWork.SystemFilesRepository.DeleteFileAsync(imagedate);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Offer");
            return actionState;
        }

        public async Task<ActionState> EditOfferAsync(EditOfferViewModel editOfferViewModel)
        {
            var actionState = new ActionState();
            var offer = _mapper.Map<EditOfferViewModel, Offer>(editOfferViewModel);
            _unitOfWork.OffersRepository.Update(offer);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                if (editOfferViewModel.Photo != null)
                {
                    var imageData = new SavingFileData()
                    {
                        File = editOfferViewModel.Photo,
                        fileName = offer.Id.ToString(),
                        folderName = "Offers"
                    };
                    await _unitOfWork.SystemFilesRepository.SaveFileAsync(imageData);
                }
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Offer");
            return actionState;
        }

        public async Task<IEnumerable<OfferViewModel>> GetAllOffersAsync()
        {
            var offers = await _unitOfWork.OffersRepository.GetElementsAsync(offer => true);

            var offersViewModel = _mapper.Map<IEnumerable<Offer>, IEnumerable<OfferViewModel>>(offers);

            return offersViewModel;
        }

        public async Task<OfferViewModel> GetOfferDetailsAsync(int Id)
        {
            var offer = await _unitOfWork.OffersRepository.FindByIdAsync(Id);

            var offerViewModel = _mapper.Map<Offer, OfferViewModel>(offer);

            return offerViewModel;
        }

        public async Task<PagedResult<OfferViewModel>> GetDashboardOffersAsync(PagingParameters pagingParameters)
        {
            var offers = await _unitOfWork.OffersRepository.GetElementsWithOrderAsync(Offer => true,
                       pagingParameters, Offer => Offer.Id, OrderingType.Descending);

            var offersViewModel = offers.ToMappedPagedResult<Offer, OfferViewModel>(_mapper);

            return offersViewModel;
        }
    }
}
