using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Offers
{
    public class OfferDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Image
        {
            get
            {
                return "/Uploads/Offers/" + Id + ".jpg?q=" + DateTime.Now.ToBinary();
            }
        }
    }
}
