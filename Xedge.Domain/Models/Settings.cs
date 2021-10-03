using Xedge.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Domain.Models
{
    public class Settings : BaseModel
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public TypeCode Type { get; set; }
    }
}
