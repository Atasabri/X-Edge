using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.Filtration
{
    public class ProductsFiltration : PagingParameters
    {
        public int[] Categories { get; set; } = new int[] { };
        public int[] SubCategories { get; set; } = new int[] { };
        public int[] Brands { get; set; } = new int[] { };
        public int[] Markets { get; set; } = new int[] { };

        public double LowPrice { get; set; } = 0;
        public double HighPrice { get; set; } = double.MaxValue;

        public OrderingBy SortBy { get; set; }
    }
}
