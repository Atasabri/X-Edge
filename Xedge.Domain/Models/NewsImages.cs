using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Xedge.Domain.Models.BaseModels;

namespace Xedge.Domain.Models
{
    public class NewsImages : BaseModel
    {
        public string Path { get; set; }
        public int News_Id { get; set; }


        [ForeignKey(nameof(News_Id))]
        public News News { get; set; }
    }
}
