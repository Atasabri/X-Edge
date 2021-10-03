using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Products
{
    public class EditProductViewModel : BaseNamedViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Arabic Description")]
        public string Description_AR { get; set; }
        [Required]
        [Display(Name = "Sub Category")]
        public int SubCategory_Id { get; set; }
        [Required]
        public double Price { get; set; }
        [Display(Name = "Old Price")]
        public double? OldPrice { get; set; }
        [Required]
        [Display(Name = "Market")]
        public int Market_Id { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public int Brand_Id { get; set; }
        [Display(Name = "Serial Number")]
        public string Serial_Number { get; set; }

        private int? offerid;
        [Display(Name = "Offer")]
        public int? Offer_Id
        {
            get { return offerid; }
            set
            {
                offerid = value == 0 ? null : value;
            }
        }
        public List<IFormFile> Photos { get; set; }
    }
}
