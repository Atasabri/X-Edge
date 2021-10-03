using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Xedge.Infrastructure.DTOs.Files
{
    public class FileDTO : BaseDTO
    {
        public string Name { get; set; }
        public double SizeinMB { get; set; }

        [JsonIgnore]
        public string Extention { get; set; }
        public string File
        {
            get
            {
                return "/Uploads/Files/" + Id + Extention +"?q=" + DateTime.Now.ToBinary();
            }
        }
    }
}
