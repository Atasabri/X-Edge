using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;

namespace Xedge.Infrastructure.DashboardViewModels.Files
{
    public class EditFileViewModel : BaseNamedViewModel
    {
        public double SizeinMB { get; set; }
        public string Extention { get; set; }
        public IFormFile File { get; set; }
    }
}
