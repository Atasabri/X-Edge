using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Offers
{
    public class EditOfferViewModel : BaseNamedViewModel
    {
        public IFormFile Photo { get; set; }

    }
}
