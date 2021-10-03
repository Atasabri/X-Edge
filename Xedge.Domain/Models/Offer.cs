using Xedge.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Domain.Models
{
    public class Offer : BaseNamedModel
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
