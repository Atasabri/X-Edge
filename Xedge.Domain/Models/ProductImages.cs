using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Xedge.Domain.Models.BaseModels;

namespace Xedge.Domain.Models
{
    public class ProductImages : BaseModel
    {
        public string Path { get; set; }
        public int Product_Id { get; set; }


        [ForeignKey(nameof(Product_Id))]
        public Product Product { get; set; }
    }
}
