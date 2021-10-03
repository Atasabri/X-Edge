using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.News
{
    public class NewsDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public string[] Images { get; set; }
    }
}
