using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Repo.Repositories.Implementation.Categories
{
    public class SubCategoriesRepository : GenericRepository<SubCategory>, ISubCategoriesRepository
    {
        public SubCategoriesRepository(DB context)
            : base(context)
        {
        }
    }
}
