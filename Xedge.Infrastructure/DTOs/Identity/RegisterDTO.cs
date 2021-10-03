﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Identity
{
    public class RegisterDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string FCM { get; set; }
    }
}
