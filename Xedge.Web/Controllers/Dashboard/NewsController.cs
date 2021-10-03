using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xedge.Business.Services.News.Interfaces.Dashboard;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.DashboardViewModels.News;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Web.Controllers.Dashboard
{
    public class NewsController : DashboardController
    {
        private readonly IDashboardNewsService _dashboardNewsService;

        public NewsController(IDashboardNewsService dashboardNewssService)
        {
            this._dashboardNewsService = dashboardNewssService;
        }
        // GET: News
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardNewsService.GetDashboardNewsAsync(pagingParameters);
            return View(result);
        }

        // GET: News/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardNewsService.GetNewsDetailsAsync(id);
            return View(result);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddNewsViewModel addNewsViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardNewsService.CreateNewsAsync(addNewsViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addNewsViewModel);
        }

        // GET: News/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardNewsService.GetNewsDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: News/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditNewsViewModel editNewsViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardNewsService.EditNewsAsync(editNewsViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var NewsViewModel = await _dashboardNewsService.GetNewsDetailsAsync(editNewsViewModel.Id);
            return View(NewsViewModel);
        }


        // POST: News/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardNewsService.DeleteNewsAsync(id);
                if (result.ExcuteSuccessfully)
                {
                    return Json(id);
                }
                return Json(result.ErrorMessages.FirstOrDefault());
            }
            return Json(0);
        }

        public async Task<ActionResult> DeleteImage(string path, int newsid)
        {
            var result = await _dashboardNewsService.DeleteNewsImageAsync(newsid, path);
            if (result.ExcuteSuccessfully)
            {
                return RedirectToAction(nameof(Edit), new { id = newsid });
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
