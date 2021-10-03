using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xedge.Business.Services.Videos.Interfaces;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Web.Controllers.APIs
{
    public class VideosController : APIController
    {
        private readonly IVideosService _videosService;

        public VideosController(IVideosService videosService)
        {
            this._videosService = videosService;
        }

        [HttpGet("GetVideos")]
        public async Task<IActionResult> GetVideos([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _videosService.GetVideosAsync(pagingParameters));
        }
    }
}
