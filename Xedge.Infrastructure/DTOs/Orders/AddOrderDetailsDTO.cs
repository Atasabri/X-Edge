using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Orders
{
    public class AddOrderDetailsDTO
    {
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
    }
}
