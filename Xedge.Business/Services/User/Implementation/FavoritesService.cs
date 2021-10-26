using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.User.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Products;
using Xedge.Infrastructure.DTOs.User.Favorites;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using Xedge.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.User.Implementation
{
    public class FavoritesService : IFavoritesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public FavoritesService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._stringLocalizer = stringLocalizer;
        }
        public async Task<ActionState> LikeProductAsync(AddOrRemoveProductToFavoritesDTO addProductToFavoritesDTO)
        {
            var actionState = new ActionState();
            // Get Current Logined User
            var userId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            // Check If Product Added to Favorites Before
            var favorite = await _unitOfWork.FavoritesRepository.FindElementAsync(fav => fav.Product_Id == addProductToFavoritesDTO.Product_Id && fav.User_Id == userId);
            if(favorite == null)
            {
                // Adding to Favorites to User If Not Added Before
                favorite = new Favorites { Product_Id = addProductToFavoritesDTO.Product_Id, User_Id = userId };
                await _unitOfWork.FavoritesRepository.CreateAsync(favorite);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (result)
                {
                    actionState.ExcuteSuccessfully = true;
                    return actionState;
                }
            }
            else
            {
                // Remove Product From Favorites If Added Before
                _unitOfWork.FavoritesRepository.Delete(favorite);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (result)
                {
                    actionState.ExcuteSuccessfully = true;
                    return actionState;
                }
            }
            actionState.ErrorMessages.Add(_stringLocalizer["Error In Adding Product To Favorites !"]);
            return actionState;
        }

        public async Task<PagedResult<ListingProductDTO>> GetUserFavoritesAsync(PagingParameters pagingParameters)
        {
            // Get Current Logined User
            var userId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            // Get Current User Favorite Products
            var favorites = await _unitOfWork.FavoritesRepository.GetElementsWithOrderAsync(fav => fav.User_Id == userId,
                pagingParameters, fav => fav.Id, OrderingType.Descending, 
                string.Format("{0}.{1},{0}.{2}", nameof(Product), nameof(Product.Market), nameof(Product.Images)));

            // Product Mapping
            var productsDTOs = favorites.ToMappedPagedResult<Favorites, ListingProductDTO>(_mapper, 
                opts => opts.AfterMap((src, dest) => {
                    foreach (var item in dest)
                    {
                        item.IsFav = true;
                    }
            }));

            return productsDTOs;
        }
    }
}
