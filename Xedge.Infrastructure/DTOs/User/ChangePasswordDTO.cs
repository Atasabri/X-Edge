﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.User
{
    public class ChangePasswordDTO
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
