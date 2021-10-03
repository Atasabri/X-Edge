using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Videos
{
    public class AddVideoViewModel
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

        [Required]
        public IFormFile Video { get; set; }
    }
}
