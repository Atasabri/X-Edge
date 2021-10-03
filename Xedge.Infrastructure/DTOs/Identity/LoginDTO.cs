using Xedge.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Identity
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FCM { get; set; }
    }
}
