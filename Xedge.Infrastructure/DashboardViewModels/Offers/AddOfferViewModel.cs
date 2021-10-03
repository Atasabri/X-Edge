using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Offers
{
    public class AddOfferViewModel : NamedViewModel
    {
        [Required]
        public IFormFile Photo { get; set; }
    }
}
