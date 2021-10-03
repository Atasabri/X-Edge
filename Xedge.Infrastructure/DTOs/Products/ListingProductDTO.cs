using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Xedge.Infrastructure.DTOs.Markets;

namespace Xedge.Infrastructure.DTOs.Products
{
    public class ListingProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public bool IsFav { get; set; }
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public int Market_Id { get; set; }
        public string [] Images { get; set; }
    }
}
