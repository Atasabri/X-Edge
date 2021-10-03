using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Products
{
    public class ListingProductViewModel : BaseNamedViewModel
    {
        [Display(Name = "Sub Category Name")]
        public string SubCategoryName { get; set; }
        [Display(Name = "Sub Category")]
        public int SubCategory_Id { get; set; }
        public double Price { get; set; }
        [Display(Name="Old Price")]
        public double? OldPrice { get; set; }
        [Display(Name = "Market")]
        public int Market_Id { get; set; }
        [Display(Name = "Market Name")]
        public string MarketName { get; set; }
        [Display(Name = "Brand")]
        public int Brand_Id { get; set; }
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
    }
}
