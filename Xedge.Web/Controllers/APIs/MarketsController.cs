using Xedge.Business.Services.Brands.Interfaces;
using Xedge.Business.Services.Markets.Interfaces;
using Xedge.Business.Services.Notifications.Interfaces;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.APIs
{
    public class MarketsController : APIController
    {
        private readonly IMarketsService _marketsService;

        public MarketsController(IMarketsService marketsService)
        {
            this._marketsService = marketsService;
        }

        [HttpGet("GetMarkets")]
        public async Task<IActionResult> GetMarkets([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _marketsService.GetMarketsAsync(pagingParameters));
        }
    }
}
