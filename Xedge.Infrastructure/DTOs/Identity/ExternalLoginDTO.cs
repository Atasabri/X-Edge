﻿using Xedge.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Identity
{
    public class ExternalLoginDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ExternalLoginId { get; set; }
        public ExternalLoginProviders ExternalLoginProvider { get; set; }
        public string FCM { get; set; }
    }
}
