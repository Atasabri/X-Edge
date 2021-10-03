using Xedge.Business.Services.Offers.Interfaces;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.APIs
{
    [Authorize(Roles = Constants.UserRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AllowAnonymous]
    public class OffersController : APIController
    {
        private readonly IOffersService _offersService;

        public OffersController(IOffersService offersService)
        {
            this._offersService = offersService;
        }

        [HttpGet("GetOffers")]
        public async Task<IActionResult> GetOffers([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _offersService.GetOffersAsync(pagingParameters));
        }

        [HttpGet("GetXedgeOffer")]
        public async Task<IActionResult> GetXedgeOffer()
        {
            return Ok(await _offersService.GetXedgeOfferAsync());
        }

        [HttpGet("GetOfferProducts/{offerId}")]
        public async Task<IActionResult> GetOfferProducts(int offerId, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _offersService.GetOfferProductsAsync(offerId, pagingParameters));
        }
    }
}
