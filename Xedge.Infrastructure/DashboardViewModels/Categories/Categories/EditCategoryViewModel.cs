using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Categories.Categories
{
    public class EditCategoryViewModel : BaseNamedViewModel
    {
        public IFormFile Photo { get; set; }
        public IFormFile Banner { get; set; }
    }
}
