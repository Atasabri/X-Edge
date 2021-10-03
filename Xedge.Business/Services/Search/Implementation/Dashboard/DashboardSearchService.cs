using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Search.Interfaces.Dashboard;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DashboardViewModels.Orders;
using Xedge.Infrastructure.DashboardViewModels.Products;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Search.Implementation.Dashboard
{
    public class DashboardSearchService : IDashboardSearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardSearchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PagedResult<ListingOrderViewModel>> SearchOrdersAsync(int id, PagingParameters pagingParameters)
        {
            var orders = await _unitOfWork.OrdersRepository.GetElementsWithOrderAsync(order => order.Id == id, pagingParameters,
                               order => order.DateTime, OrderingType.Descending);

            var ordersViewModel = orders.ToMappedPagedResult<Order, ListingOrderViewModel>(_mapper);
            return ordersViewModel;
        }

        public async Task<PagedResult<ListingProductViewModel>> SearchProductsAsync(string searchTerms, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository.GetElementsWithOrderAsync(product => product.Name.Contains(searchTerms) || product.Name_AR.Contains(searchTerms) || product.Serial_Number == searchTerms,
                              pagingParameters, Product => Product.Id, OrderingType.Descending,
                              nameof(Product.SubCategory));

            var productsViewModel = products.ToMappedPagedResult<Product, ListingProductViewModel>(_mapper);

            return productsViewModel;
        }
    }
}
