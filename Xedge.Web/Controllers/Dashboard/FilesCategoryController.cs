using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xedge.Business.Services.Files.Interfaces.Dashboard;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.DashboardViewModels.Files;
using Xedge.Infrastructure.DashboardViewModels.Files_Category.Files;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Web.Controllers.Dashboard
{
    public class FilesCategoryController : DashboardController
    {
        private readonly IDashboardFilesCategoryService _dashboardFilesCategoryService;

        public FilesCategoryController(IDashboardFilesCategoryService dashboardFilesCategoryService)
        {
            this._dashboardFilesCategoryService = dashboardFilesCategoryService;
        }
        // GET: FilesCategory
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardFilesCategoryService.GetDashboardFilesCategoriesAsync(pagingParameters);
            return View(result);
        }

        // GET: FilesCategory/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardFilesCategoryService.GetFileCategoryDetailsAsync(id);
            return View(result);
        }

        // GET: FilesCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilesCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddFileCategoryViewModel addFileCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardFilesCategoryService.CreateFileCategoryAsync(addFileCategoryViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addFileCategoryViewModel);
        }

        // GET: FilesCategory/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardFilesCategoryService.GetFileCategoryDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: FilesCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditFileCategoryViewModel editFileCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardFilesCategoryService.EditFileCategoryAsync(editFileCategoryViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var FileViewModel = await _dashboardFilesCategoryService.GetFileCategoryDetailsAsync(editFileCategoryViewModel.Id);
            return View(FileViewModel);
        }


        // POST: FilesCategory/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardFilesCategoryService.DeleteFileCategoryAsync(id);
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
