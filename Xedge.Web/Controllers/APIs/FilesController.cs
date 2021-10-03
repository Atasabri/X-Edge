using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xedge.Business.Services.Files.Interfaces;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Web.Controllers.APIs
{
    public class FilesController : APIController
    {
        private readonly IFilesService _filesService;

        public FilesController(IFilesService filesService)
        {
            this._filesService = filesService;
        }

        [HttpGet("GetFiles")]
        public async Task<IActionResult> GetFiles([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _filesService.GetFilesAsync(pagingParameters));
        }
    }
}
