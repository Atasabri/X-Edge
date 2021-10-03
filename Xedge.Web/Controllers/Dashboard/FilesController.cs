using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xedge.Business.Services.Files.Interfaces.Dashboard;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.DashboardViewModels.Files;
using Xedge.Infrastructure.Pagination;

namespace Xedge.Web.Controllers.Dashboard
{
    public class FilesController : DashboardController
    {
        private readonly IDashboardFilesService _dashboardFilesService;

        public FilesController(IDashboardFilesService dashboardFilesService)
        {
            this._dashboardFilesService = dashboardFilesService;
        }
        // GET: Files
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardFilesService.GetDashboardFilesAsync(pagingParameters);
            return View(result);
        }

        // GET: Files/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardFilesService.GetFileDetailsAsync(id);
            return View(result);
        }

        // GET: Files/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Files/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddFileViewModel addFileViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardFilesService.CreateFileAsync(addFileViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addFileViewModel);
        }

        // GET: Files/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardFilesService.GetFileDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Files/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditFileViewModel editFileViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardFilesService.EditFileAsync(editFileViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var FileViewModel = await _dashboardFilesService.GetFileDetailsAsync(editFileViewModel.Id);
            return View(FileViewModel);
        }


        // POST: Files/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardFilesService.DeleteFileAsync(id);
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
