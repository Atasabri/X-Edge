using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xedge.Business.Services.News.Interfaces;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Web.Controllers.APIs
{
    public class NewsController : APIController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            this._newsService = newsService;
        }

        [HttpGet("GetNews")]
        public async Task<IActionResult> GetNews([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _newsService.GetNewsAsync(pagingParameters));
        }

        [HttpGet("GetTodayNews")]
        public async Task<IActionResult> GetTodayNews([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _newsService.GetTodayNewsAsync(pagingParameters));
        }
    }
}
