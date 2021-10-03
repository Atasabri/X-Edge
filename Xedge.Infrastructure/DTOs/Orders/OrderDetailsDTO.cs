using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Orders
{
    public class OrderDetailsDTO
    {
        public int Product_Id { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public string ProductName { get; set; }

        public string[] Images { get; set; }
    }
}
