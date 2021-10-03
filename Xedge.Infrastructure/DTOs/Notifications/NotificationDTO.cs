using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Notifications
{
    public class NotificationDTO
    {
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public int? Order_Id { get; set; }
    }
}
