using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;

namespace Xedge.Infrastructure.DashboardViewModels.Videos
{
    public class VideoViewModel : BaseViewModel
    {
        public string Title { get; set; }
        [Display(Name = "Title (Arabic)")]
        public string Title_AR { get; set; }
        public string Description { get; set; }
        [Display(Name = "Description (Arabic)")]
        public string Description_AR { get; set; }
    }
}
