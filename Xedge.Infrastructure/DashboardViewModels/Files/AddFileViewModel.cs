using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;

namespace Xedge.Infrastructure.DashboardViewModels.Files
{
    public class AddFileViewModel : NamedViewModel
    {
        [Required]
        public IFormFile File { get; set; }

        [Display(Name = "Category")]
        public int Category_Id { get; set; }
    }
}
