using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xedge.Repo.Repositories.Implementation.Brands
{
    public class BrandsRepository : GenericRepository<Brand>, IBrandsRepository
    {
        public BrandsRepository(DB context)
            : base(context)
        {
        }
    }
}
