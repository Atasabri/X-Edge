using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Models.BaseModels;

namespace Xedge.Domain.Models
{
    public class File : BaseNamedModel
    {
        public double SizeinMB { get; set; }
        public string Extention { get; set; }
    }
}
