using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.News
{
    public class NewsViewModel : ListingNewsViewModel
    {
        [Display(Name = "Title (Arabic)")]
        public string Title_AR { get; set; }
        public string Description { get; set; }
        [Display(Name = "Description (Arabic)")]
        public string Description_AR { get; set; }

        public string[] Images { get; set; }
    }
}
