using Xedge.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xedge.Domain.Models
{
    public class SubCategory : BaseNamedModel
    {
        [Required]
        public int Category_Id { get; set; }


        [ForeignKey(nameof(Category_Id))]
        public Category Category { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
