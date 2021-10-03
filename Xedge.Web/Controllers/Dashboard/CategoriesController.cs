using Xedge.Business.Services.Categories.Interfaces.Dashboard;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.DashboardViewModels.Categories.Categories;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.Dashboard
{
    public class CategoriesController : DashboardController
    {
        private readonly IDashboardCategoriesService _dashboardCategoriesService;

        public CategoriesController(IDashboardCategoriesService dashboardCategoriesService)
        {
            this._dashboardCategoriesService = dashboardCategoriesService;
        }
        // GET: Categories
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardCategoriesService.GetDashboardCategoriesAsync(pagingParameters);
            return View(result);
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardCategoriesService.GetCategoryDetailsAsync(id);
            return View(result);
        }

        // GET: Categories/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardCategoriesService.CreateCategoryAsync(addCategoryViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }

            return View(addCategoryViewModel);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardCategoriesService.GetCategoryDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditCategoryViewModel editCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardCategoriesService.EditCategoryAsync(editCategoryViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var categoryViewModel = await _dashboardCategoriesService.GetCategoryDetailsAsync(editCategoryViewModel.Id);
            return View(categoryViewModel);
        }


        // POST: Categories/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardCategoriesService.DeleteCategoryAsync(id);
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
