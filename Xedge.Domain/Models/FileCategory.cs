using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Models.BaseModels;

namespace Xedge.Domain.Models
{
    public class FileCategory : BaseNamedModel
    {
        public virtual ICollection<File> Files { get; set; }

    }
}
