using Xedge.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Identity
{
    public class LoginState
    {
        public bool LoginSuccessfully { get; set; }
        public string Token { get; set; }
        public string User_Id { get; set; }
    }
}
