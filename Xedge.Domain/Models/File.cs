using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Xedge.Domain.Models.BaseModels;

namespace Xedge.Domain.Models
{
    public class File : BaseNamedModel
    {
        public double SizeinMB { get; set; }
        public string Extention { get; set; }

        public int Category_Id { get; set; }


        [ForeignKey(nameof(Category_Id))]
        public FileCategory Category { get; set; }
    }
}
