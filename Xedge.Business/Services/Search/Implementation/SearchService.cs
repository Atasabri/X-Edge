﻿using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Search.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Products;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Search.Implementation
{
    public class SearchService : ISearchService
    {
        int[] currentUserFavoritesProductsIds = new int[] { };
        Action<IMappingOperationOptions<IEnumerable<Product>, IEnumerable<ListingProductDTO>>> opts = null;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            // Change Current User Favorites Variable & Map Listing ProductDTO IsFav Property if User Logedin 
            if (_unitOfWork.UsersRepository.CheckIfUserLogedin())
            {
                var userId = _unitOfWork.UsersRepository.GetCurrentUserId().Result;
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
        public async Task<PagedResult<ListingProductDTO>> SearchAsync(string searchTerms, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                .GetElementsAsync(product => product.Name.Contains(searchTerms) || product.Name_AR.Contains(searchTerms) || product.Serial_Number == searchTerms
                , pagingParameters, string.Format("{0},{1}", nameof(Product.Market), nameof(Product.Images)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }
    }
}
