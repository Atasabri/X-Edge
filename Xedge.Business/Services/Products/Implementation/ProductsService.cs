using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Products.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Products;
using Xedge.Infrastructure.Filtration;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Products.Implementation
{
    public class ProductsService : IProductsService
    {
        int[] currentUserFavoritesProductsIds = new int[] { };
        Action<IMappingOperationOptions<IEnumerable<Product>, IEnumerable<ListingProductDTO>>> opts = null;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;     
            // Change Current User Favorites Variable & Map Listing ProductDTO IsFav Property if User Logedin 
            if(_unitOfWork.CurrentUserRepository.CheckIfUserLogedin())
            {
                var userId =  _unitOfWork.CurrentUserRepository.GetCurrentUserId().Result;
                currentUserFavoritesProductsIds = _unitOfWork.FavoritesRepository
                    .GetElementsAsync(fav => fav.User_Id == userId).Result.Select(fav => fav.Product_Id).ToArray();

                opts = opts => opts.AfterMap((src, dest) => {
                    foreach (var item in dest)
                    {
                        item.IsFav = currentUserFavoritesProductsIds.Contains(item.Id);
                    }
                });
            }
        }
        public async Task<ProductDTO> GetProductAsync(int id)
        {
            var product = await _unitOfWork.ProductsRepository
                   .FindElementAsync(product => product.Id == id,
                   string.Format("{0},{1},{2},{3}",
                   nameof(Product.Market), nameof(Product.SubCategory),
                   nameof(Product.Brand), nameof(Product.Images)));

            var productDTO = _mapper.Map<Product, ProductDTO>(product);

            productDTO.IsFav = currentUserFavoritesProductsIds.Contains(id);

            return productDTO;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsWithOrderAsync(product => true
                   , pagingParameters
                   , product => product.Id, OrderingType.Descending
                   , string.Format("{0},{1}", nameof(Product.Market), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsHasDiscountAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsAsync(product => product.OldPrice.HasValue
                   , pagingParameters
                   , string.Format("{0},{1}", nameof(Product.Market), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsMostSellAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsWithOrderAsync(product => product.OrderDetails.Count > 1
                   , pagingParameters
                   , product => product.OrderDetails.Count
                   , OrderingType.Descending,
                   string.Format("{0},{1},{2}", nameof(Product.Market), nameof(Product.OrderDetails), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsUsingCategoryIdAsync(int catId, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsAsync(product => product.SubCategory.Category_Id == catId
                   , pagingParameters
                   , string.Format("{0},{1},{2}", nameof(Product.Market)
                   , nameof(Product.SubCategory), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }
        public async Task<PagedResult<ListingProductDTO>> GetProductsUsingSubCategoryIdAsync(int subCatId, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsAsync(product => product.SubCategory_Id == subCatId
                   , pagingParameters
                   , string.Format("{0},{1}", nameof(Product.Market), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsUsingBrandIdAsync(int brandId, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                    .GetElementsAsync(product => product.Brand_Id == brandId
                    , pagingParameters
                    , string.Format("{0},{1},{2}", nameof(Product.Market)
                    , nameof(Product.SubCategory), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsRecommendedAsync(int productId, PagingParameters pagingParameters)
        {
            var product = await _unitOfWork.ProductsRepository.FindElementAsync(product => product.Id == productId,
                                nameof(Product.SubCategory));

            var products = await _unitOfWork.ProductsRepository.GetElementsAsync(prod =>
                                 prod.SubCategory.Category_Id == product.SubCategory.Category_Id
                                , pagingParameters
                                , string.Format("{0},{1},{2}", nameof(Product.Market)
                                , nameof(product.SubCategory), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsWithFiltrationAsync(ProductsFiltration productsFiltration)
        {
            var pagingParameters = new PagingParameters(productsFiltration.Index, productsFiltration.Size);


            var products = await _unitOfWork.ProductsRepository
                                .GetElementsWithOrderAsync(product =>
                                (productsFiltration.Categories.Length <= 0 || productsFiltration.Categories.Contains(product.SubCategory.Category_Id)) &&
                                (productsFiltration.SubCategories.Length <= 0 || productsFiltration.SubCategories.Contains(product.SubCategory_Id)) &&
                                (productsFiltration.Brands.Length <= 0 || productsFiltration.Brands.Contains(product.Brand_Id)) &&
                                (productsFiltration.Markets.Length <= 0 || productsFiltration.Markets.Contains(product.Market_Id)) &&
                                product.Price <= productsFiltration.HighPrice && product.Price >= productsFiltration.LowPrice
                                , pagingParameters
                                , SortBy(productsFiltration.SortBy)
                                , productsFiltration.SortBy == OrderingBy.HighToLowPrice ? OrderingType.Descending : OrderingType.Ascending,
                                string.Format("{0},{1}.{2},{3}", nameof(Product.Market), nameof(Product.SubCategory),
                                nameof(Product.SubCategory.Category), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        /// <summary>
        /// Filtration Sort By For Product Used in Lambda Expression
        /// </summary>
        /// <param name="orderingBy"></param>
        /// <returns></returns>
        private Expression<Func<Product, object>> SortBy(OrderingBy orderingBy)
        {
            if (orderingBy == OrderingBy.Name)
            {
                return product => product.Name;
            }
            else
            {
                return product => product.Price;
            }
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsWithZeroCostAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                          .GetElementsWithOrderAsync(product => product.Price == 0
                          , pagingParameters
                          , product => product.Id
                          , OrderingType.Descending
                          , string.Format("{0},{1}", nameof(Product.Market), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }
    }
}
