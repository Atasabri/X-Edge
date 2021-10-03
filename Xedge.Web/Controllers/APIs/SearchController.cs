using Xedge.Business.Services.Search.Interfaces;
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
    public class SearchController : APIController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }

        [HttpGet("Search/{searchTerms}")]
        public async Task<IActionResult> Search(string searchTerms, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _searchService.SearchAsync(searchTerms, pagingParameters));
        }
    }
}
