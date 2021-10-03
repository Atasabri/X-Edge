using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Categories
{
    public class CategoryIncludeSubCategoriesDTO : CategoryDTO
    {
        public IEnumerable<SubCategoryDTO> SubCategories { get; set; }
    }
}
