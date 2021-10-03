using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DashboardViewModels.Orders
{
    public class OrderDetailsViewModel : BaseViewModel
    {
        public double Price { get; set; }
        public int Quantity { get; set; }

        public int Product_Id { get; set; }

        public string ProductName { get; set; }
    }
}
