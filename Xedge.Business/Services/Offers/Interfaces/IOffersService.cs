using Xedge.Infrastructure.DTOs.Offers;
using Xedge.Infrastructure.DTOs.Products;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Offers.Interfaces
{
    public interface IOffersService
    {
        /// <summary>
        /// Get All Offers (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingparameters"></param>
        /// <returns></returns>
        Task<PagedResult<OfferDTO>> GetOffersAsync(PagingParameters pagingparameters);
        /// <summary>
        /// Get Static Offer (X-Edge Offer)
        /// </summary>
        /// <returns></returns>
        Task<OfferDTO> GetXedgeOfferAsync();
        /// <summary>
        /// Get Products Using Offer Id (Asynchronous & Paging)
        /// </summary>
        /// <param name="offerId"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetOfferProductsAsync(int offerId, PagingParameters pagingParameters);
    }
}
