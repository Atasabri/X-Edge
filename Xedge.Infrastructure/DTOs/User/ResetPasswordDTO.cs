﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.User
{
    public class ResetPasswordDTO
    {
        public string Phone { get; set; }
        public string ResetPasswordToken { get; set; }
        public string NewPassword { get; set; }
    }
}
