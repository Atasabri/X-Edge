using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Markets
{
    public class AddMarketViewModel : NamedViewModel
    {
        [Required]
        public IFormFile Photo { get; set; }
    }
}
