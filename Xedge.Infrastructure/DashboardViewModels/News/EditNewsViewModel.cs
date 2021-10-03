using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using Xedge.Infrastructure.Helpers;

namespace Xedge.Infrastructure.DashboardViewModels.News
{
    public class EditNewsViewModel : BaseViewModel
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
        public DateTime Date { get; set; } = DateTimeProvider.GetEgyptDateTime();

        public List<IFormFile> Photos { get; set; }
    }
}
