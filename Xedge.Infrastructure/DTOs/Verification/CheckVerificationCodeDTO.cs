﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Verification
{
    public class CheckVerificationCodeDTO
    {
        public string Phone { get; set; }
        public string SmsId { get; set; }
        public int Code { get; set; }
    }
}
