using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Products
{
    public class ProductViewModel : ListingProductViewModel
    {
        public string Description { get; set; }
        [Display(Name = "Arabic Description")]
        public string Description_AR { get; set; }
        [Display(Name = "Offer Name")]
        public string OfferName { get; set; }
        [Display(Name = "Serial Number")]
        public string Serial_Number { get; set; }

        [Display(Name = "Offer")]
        public int? Offer_Id { get; set; }
        public string[] Images { get; set; }
    }
}
