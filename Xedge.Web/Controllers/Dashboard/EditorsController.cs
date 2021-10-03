﻿using Xedge.Business.Services.User.Interfaces.Dashboard;
using Xedge.Infrastructure.DashboardViewModels.Identity;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.Dashboard
{
    [Authorize(Roles = Admin.AdminRoleName)]
    public class EditorsController : Controller
    {
        private readonly IDashboardUserService _dashboardUserService;

        public EditorsController(IDashboardUserService dashboardUserService)
        {
            this._dashboardUserService = dashboardUserService;
        }
        public async Task<IActionResult> Index()
        {
            var editors = await _dashboardUserService.GetEditorsAsync();
            return View(editors);
        }
        public IActionResult AddNewEditor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEditor(AddNewAdminViewModel addNewAdminViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardUserService.CreateNewEditorAsync(addNewAdminViewModel);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
            }
            return View(addNewAdminViewModel);
        }
    }
}
