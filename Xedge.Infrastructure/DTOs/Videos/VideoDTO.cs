using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Videos
{
    public class VideoDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Video
        {
            get
            {
                return "/Uploads/Videos/" + Id + ".mp4?q=" + DateTime.Now.ToBinary();
            }
        }

    }
}
