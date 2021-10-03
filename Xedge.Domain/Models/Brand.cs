using Xedge.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xedge.Domain.Models
{
    public class Brand : BaseNamedModel
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
