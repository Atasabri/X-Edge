﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Xedge.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Xedge.Domain.Models
{
    public class User : IdentityUser
    {
        public string FCM { get; set; }
        [Required]
        public Languages CurrentLangauge { get; set; } = Languages.EN;
        public string FullName { get; set; }
        public double Balance { get; set; }


        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<PaymentMethod> Payments { get; set; }

        public ICollection<Favorites> Favorites { get; set; }

        public ICollection<WalletTransaction> WalletTransactions { get; set; }
    }
}
