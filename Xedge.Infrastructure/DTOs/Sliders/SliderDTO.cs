using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Sliders
{
    public class SliderDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Image
        {
            get
            {
                return "/Uploads/Sliders/" + Id + ".jpg?q=" + DateTime.Now.ToBinary();
            }
        }
    }
}
