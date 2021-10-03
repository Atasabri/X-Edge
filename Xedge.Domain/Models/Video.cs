using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Models.BaseModels;

namespace Xedge.Domain.Models
{
    public class Video : BaseModel
    {
        public string Title { get; set; }
        public string Title_AR { get; set; }
        public string Description { get; set; }
        public string Description_AR { get; set; }
    }
}
