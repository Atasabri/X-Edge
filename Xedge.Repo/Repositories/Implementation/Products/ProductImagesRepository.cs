using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Products;

namespace Xedge.Repo.Repositories.Implementation.Products
{
    public class ProductImagesRepository : GenericRepository<ProductImages>, IProductImagesRepository
    {
        public ProductImagesRepository(DB context)
            : base(context)
        {
        }
    }
}
