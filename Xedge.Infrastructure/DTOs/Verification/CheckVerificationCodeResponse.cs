﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Verification
{
    public class CheckVerificationCodeResponse
    {
        public bool Status { get; set; }
        public string ResetPasswordToken { get; set; }
        public string Error { get; set; }
    }
}
