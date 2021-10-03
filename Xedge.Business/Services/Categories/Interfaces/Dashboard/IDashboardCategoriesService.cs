using Xedge.Infrastructure.DashboardViewModels.Categories;
using Xedge.Infrastructure.DashboardViewModels.Categories.Categories;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Categories.Interfaces.Dashboard
{
    public interface IDashboardCategoriesService
    {
        /// <summary>
        /// Adding New Category Asynchronous
        /// </summary>
        /// <param name="addCategoryViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateCategoryAsync(AddCategoryViewModel addCategoryViewModel);
        /// <summary>
        /// Edit Category Asynchronous
        /// </summary>
        /// <param name="editCategoryViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditCategoryAsync(EditCategoryViewModel editCategoryViewModel);
        /// <summary>
        /// Delete Category Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteCategoryAsync(int id);
        /// <summary>
        /// Get Categories (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<CategoryViewModel>> GetDashboardCategoriesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Category Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<CategoryViewModel> GetCategoryDetailsAsync(int Id);
        /// <summary>
        /// Get All Categories Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
