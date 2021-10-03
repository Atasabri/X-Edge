using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Models.BaseModels;

namespace Xedge.Domain.Models
{
    public class News : BaseModel
    {
        public string Title { get; set; }
        public string Title_AR { get; set; }
        public string Description { get; set; }
        public string Description_AR { get; set; }
        public DateTime Date { get; set; }


        public virtual ICollection<NewsImages> Images { get; set; }
    }
}
