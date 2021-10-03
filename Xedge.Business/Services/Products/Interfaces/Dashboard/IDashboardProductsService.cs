using Xedge.Infrastructure.DashboardViewModels.Products;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Products.Interfaces.Dashboard
{
    public interface IDashboardProductsService
    {
        /// <summary>
        /// Adding New Product Asynchronous
        /// </summary>
        /// <param name="addProductViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateProductAsync(AddProductViewModel addProductViewModel);
        /// <summary>
        /// Edit Product Asynchronous
        /// </summary>
        /// <param name="editProductViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditProductAsync(EditProductViewModel editProductViewModel);
        /// <summary>
        /// Delete Product Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteProductAsync(int id);
        /// <summary>
        /// Get Products (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductViewModel>> GetDashboardProductsAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Product Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<ProductViewModel> GetProductDetailsAsync(int Id);
        /// <summary>
        /// Delete Image From Product Asynchronous
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<ActionState> DeleteProductImageAsync(int productId, string path);
    }
}
