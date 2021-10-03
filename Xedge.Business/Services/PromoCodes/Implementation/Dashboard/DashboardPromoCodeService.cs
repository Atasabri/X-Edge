﻿using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.PromoCodes.Interfaces.Dashboard;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.PromoCodes;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Manage_Files;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.PromoCodes.Implementation.Dashboard
{
    public class DashboardPromoCodeService : IDashboardPromoCodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardPromoCodeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreatePromoCodeAsync(AddPromoCodeViewModel addPromoCodeViewModel)
        {
            var createState = new CreateState();
            var promoCode = _mapper.Map<AddPromoCodeViewModel, PromoCode>(addPromoCodeViewModel);

            await _unitOfWork.PromoCodesRepository.CreateAsync(promoCode);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create PromoCode");
            return createState;
        }

        public async Task<ActionState> DeletePromoCodeAsync(int id)
        {
            var actionState = new ActionState();
            var promoCode = await _unitOfWork.PromoCodesRepository.FindByIdAsync(id);
            if (promoCode == null)
            {
                actionState.ErrorMessages.Add("Can Not Find PromoCode !");
                return actionState;
            }
            _unitOfWork.PromoCodesRepository.Delete(promoCode);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete PromoCode");
            return actionState;
        }

        public async Task<ActionState> EditPromoCodeAsync(EditPromoCodeViewModel editPromoCodeViewModel)
        {
            var actionState = new ActionState();
            var promoCode = _mapper.Map<EditPromoCodeViewModel, PromoCode>(editPromoCodeViewModel);
            _unitOfWork.PromoCodesRepository.Update(promoCode);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit PromoCode");
            return actionState;
        }

        public async Task<PromoCodeViewModel> GetPromoCodeDetailsAsync(int Id)
        {
            var promoCode = await _unitOfWork.PromoCodesRepository.FindByIdAsync(Id);

            var promoCodeViewModel = _mapper.Map<PromoCode, PromoCodeViewModel>(promoCode);

            return promoCodeViewModel;
        }

        public async Task<PagedResult<PromoCodeViewModel>> GetDashboardPromoCodesAsync(PagingParameters pagingParameters)
        {
            var promoCodes = await _unitOfWork.PromoCodesRepository.GetElementsWithOrderAsync(PromoCode => true,
                       pagingParameters, PromoCode => PromoCode.Id, OrderingType.Descending);

            var promoCodesViewModel = promoCodes.ToMappedPagedResult<PromoCode, PromoCodeViewModel>(_mapper);

            return promoCodesViewModel;
        }
    }
}
