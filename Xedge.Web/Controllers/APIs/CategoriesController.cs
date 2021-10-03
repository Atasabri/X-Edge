using Xedge.Business.Services.Categories.Interfaces;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.Apis
{
    public class CategoriesController : APIController
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this._categoriesService = categoriesService;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _categoriesService.GetCategoriesAsync(pagingParameters));
        }

        [HttpGet("GetCategoriesIncludeSubCategories")]
        public async Task<IActionResult> GetCategoriesIncludeSubCategories([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _categoriesService.GetCategoriesIncludeSubCategoriesAsync(pagingParameters));
        }

        [HttpGet("GetSubCategories/{categoryId}")]
        public async Task<IActionResult> GetSubCategories(int categoryId, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _categoriesService.GetSubCategoriesAsync(categoryId, pagingParameters));
        }
    }
}
