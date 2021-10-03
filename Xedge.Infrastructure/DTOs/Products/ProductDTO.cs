using Xedge.Infrastructure.DTOs.Brand;
using Xedge.Infrastructure.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Xedge.Infrastructure.DTOs.Markets;

namespace Xedge.Infrastructure.DTOs.Products
{
    public class ProductDTO : ListingProductDTO
    {
        public string Description { get; set; }
        public SubCategoryDTO SubCategory { get; set; }
        public BrandDTO Brand { get; set; }
        public MarketDTO Market { get; set; }
    }
}
