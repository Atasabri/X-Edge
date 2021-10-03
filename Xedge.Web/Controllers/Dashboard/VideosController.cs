using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xedge.Business.Services.Videos.Interfaces.Dashboard;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.DashboardViewModels.Videos;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Web.Controllers.Dashboard
{
    public class VideosController : DashboardController
    {
        private readonly IDashboardVideosService _dashboardVideosService;

        public VideosController(IDashboardVideosService dashboardVideosService)
        {
            this._dashboardVideosService = dashboardVideosService;
        }
        // GET: Videos
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardVideosService.GetDashboardVideosAsync(pagingParameters);
            return View(result);
        }

        // GET: Videos/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardVideosService.GetVideoDetailsAsync(id);
            return View(result);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddVideoViewModel addVideoViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardVideosService.CreateVideoAsync(addVideoViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addVideoViewModel);
        }

        // GET: Videos/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardVideosService.GetVideoDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Videos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditVideoViewModel editVideoViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardVideosService.EditVideoAsync(editVideoViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var VideoViewModel = await _dashboardVideosService.GetVideoDetailsAsync(editVideoViewModel.Id);
            return View(VideoViewModel);
        }


        // POST: Videos/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardVideosService.DeleteVideoAsync(id);
                if (result.ExcuteSuccessfully)
                {
                    return Json(id);
                }
                return Json(result.ErrorMessages.FirstOrDefault());
            }
            return Json(0);
        }
    }
}
