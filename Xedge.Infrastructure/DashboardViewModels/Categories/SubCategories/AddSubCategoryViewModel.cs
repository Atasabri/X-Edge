﻿using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Categories.SubCategories
{
    public class AddSubCategoryViewModel : NamedViewModel
    {
        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int Category_Id { get; set; }
    }
}
