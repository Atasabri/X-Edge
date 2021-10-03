using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Offers.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Offers;
using Xedge.Infrastructure.DTOs.Products;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Offers.Implementation
{
    public class OffersService : IOffersService
    {
        int[] currentUserFavoritesProductsIds = new int[] { };
        Action<IMappingOperationOptions<IEnumerable<Product>, IEnumerable<ListingProductDTO>>> opts = null;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OffersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            // Change Current User Favorites Variable & Map Listing ProductDTO IsFav Property if User Logedin 
            if (_unitOfWork.UsersRepository.CheckIfUserLogedin())
            {
                var userId = _unitOfWork.UsersRepository.GetCurrentUserId().Result;
                currentUserFavoritesProductsIds = _unitOfWork.FavoritesRepository
                    .GetElementsAsync(fav => fav.User_Id == userId).Result.Select(fav => fav.Product_Id).ToArray();

                opts = opts => opts.AfterMap((src, dest) => {
                    foreach (var item in dest)
                    {
                        item.IsFav = currentUserFavoritesProductsIds.Contains(item.Id);
                    }
                });
            }
        }
        public async Task<OfferDTO> GetXedgeOfferAsync()
        {
            var XedgeOffer = await _unitOfWork.OffersRepository.FindByIdAsync(Constants.XedgeOfferId);

            var XedgeOfferDTO = _mapper.Map<Offer, OfferDTO>(XedgeOffer);

            return XedgeOfferDTO;
        }

        public async Task<PagedResult<ListingProductDTO>> GetOfferProductsAsync(int offerId, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository.GetElementsWithOrderAsync(product => product.Offer_Id == offerId
                                 , pagingParameters
                                 , product => product.Id, OrderingType.Descending
                                 , string.Format("{0},{1}", nameof(Product.Market), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);
            return productsDTOs;
        }

        public async Task<PagedResult<OfferDTO>> GetOffersAsync(PagingParameters pagingparameters)
        {
            // Getting All Offers With Desc Order Except X-Edge Offer
            var offers = await _unitOfWork.OffersRepository.GetElementsWithOrderAsync(offer => offer.Id != Constants.XedgeOfferId
                              , pagingparameters
                              , offer => offer.Id , OrderingType.Descending);

            var offersDTOs = offers.ToMappedPagedResult<Offer, OfferDTO>(_mapper);
            return offersDTOs;
        }
    }
}
