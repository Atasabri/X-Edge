using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;

namespace Xedge.Infrastructure.DashboardViewModels.Videos
{
    public class EditVideoViewModel : BaseViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Title (Arabic)")]
        public string Title_AR { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Description (Arabic)")]
        public string Description_AR { get; set; }

        public IFormFile Video { get; set; }
    }
}
