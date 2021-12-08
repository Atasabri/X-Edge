using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;

namespace Xedge.Infrastructure.DashboardViewModels.Files
{
    public class FileViewModel : BaseNamedViewModel
    {
        [Display(Name = "Size")]
        public double SizeinMB { get; set; }
        public string Extention { get; set; }

        [Display(Name = "Category")]
        public int Category_Id { get; set; }
    }
}
