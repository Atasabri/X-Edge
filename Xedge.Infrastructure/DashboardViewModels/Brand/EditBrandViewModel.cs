using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Brand
{
    public class EditBrandViewModel : BaseNamedViewModel
    {
        public IFormFile Photo { get; set; }

    }
}
