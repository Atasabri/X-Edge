﻿using Xedge.Business.Services.Brands.Interfaces.Dashboard;
using Xedge.Business.Services.Categories.Interfaces.Dashboard;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.DashboardViewModels.Categories.SubCategories;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.Dashboard
{
    public class SubCategoriesController : DashboardController
    {
        private readonly IDashboardSubCategoriesService _dashboardSubCategoriesService;
        private readonly IDashboardCategoriesService _dashboardCategoriesService;

        public SubCategoriesController(IDashboardSubCategoriesService dashboardSubCategoriesService,
            IDashboardCategoriesService dashboardCategoriesService)
        {
            this._dashboardSubCategoriesService = dashboardSubCategoriesService;
            this._dashboardCategoriesService = dashboardCategoriesService;
        }
        // GET: SubCategories
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardSubCategoriesService.GetDashboardSubCategoriesAsync(pagingParameters);
            return View(result);
        }

        // GET: SubCategories/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardSubCategoriesService.GetSubCategoryDetailsAsync(id);
            return View(result);
        }

        // GET: SubCategories/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = await _dashboardCategoriesService.GetAllCategoriesAsync();
            return View();
        }

        // POST: SubCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddSubCategoryViewModel addSubCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardSubCategoriesService.CreateSubCategoryAsync(addSubCategoryViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }

            ViewBag.Categories = await _dashboardCategoriesService.GetAllCategoriesAsync();
            return View(addSubCategoryViewModel);
        }

        // GET: SubCategories/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardSubCategoriesService.GetSubCategoryDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _dashboardCategoriesService.GetAllCategoriesAsync();
            return View(result);
        }

        // POST: SubCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditSubCategoryViewModel editSubCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardSubCategoriesService.EditSubCategoryAsync(editSubCategoryViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var subCategoryViewModel = await _dashboardSubCategoriesService.GetSubCategoryDetailsAsync(editSubCategoryViewModel.Id);
            ViewBag.Categories = await _dashboardCategoriesService.GetAllCategoriesAsync();
            return View(subCategoryViewModel);
        }


        // POST: SubCategories/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardSubCategoriesService.DeleteSubCategoryAsync(id);
                if (result.ExcuteSuccessfully)
                {
                    return Json(id);
                }
                return Json(result.ErrorMessages.FirstOrDefault());
            }
            return Json(0);
        }

        // GET: SubCategories?catId=1
        public async Task<ActionResult> SubCategoriesUsingCatId(int catId)
        {
            var result = await _dashboardSubCategoriesService.GetAllSubCategoriesUsingCategoryIdAsync(catId);
            return Json(result);
        }
    }
}
