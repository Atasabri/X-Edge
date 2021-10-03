﻿using Xedge.Business.Services.Brands.Interfaces.Dashboard;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.DashboardViewModels.Brand;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.Dashboard
{
    public class BrandsController : DashboardController
    {
        private readonly IDashboardBrandsService _dashboardBrandsService;

        public BrandsController(IDashboardBrandsService dashboardBrandsService)
        {
            this._dashboardBrandsService = dashboardBrandsService;
        }
        // GET: Brands
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardBrandsService.GetDashboardBrandsAsync(pagingParameters);
            return View(result);
        }

        // GET: Brands/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardBrandsService.GetBrandDetailsAsync(id);
            return View(result);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddBrandViewModel addBrandViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardBrandsService.CreateBrandAsync(addBrandViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addBrandViewModel);
        }

        // GET: Brands/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardBrandsService.GetBrandDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Brands/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditBrandViewModel editBrandViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardBrandsService.EditBrandAsync(editBrandViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var brandViewModel = await _dashboardBrandsService.GetBrandDetailsAsync(editBrandViewModel.Id);
            return View(brandViewModel);
        }


        // POST: Brands/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardBrandsService.DeleteBrandAsync(id);
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
