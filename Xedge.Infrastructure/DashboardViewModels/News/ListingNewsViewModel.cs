using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Infrastructure.DashboardViewModels.BaseViewModels;

namespace Xedge.Infrastructure.DashboardViewModels.News
{
    public class ListingNewsViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
