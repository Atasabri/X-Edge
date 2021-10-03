using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Repo.Repositories.Implementation.Products
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(DB context)
            : base(context)
        {
        }

        public Task<IEnumerable<Product>> GetProductsRecommendedAsync(PagingParameters pagingParameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsWithFiltrationAsync(PagingParameters pagingParameters)
        {
            throw new NotImplementedException();
        }
    }
}
