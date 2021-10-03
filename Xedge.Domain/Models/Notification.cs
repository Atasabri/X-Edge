﻿using Xedge.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xedge.Domain.Models
{
    public class Notification : BaseModel
    {
        public string Message { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        [Required]
        public string User_Id { get; set; }

        public int? Order_Id { get; set; }


        [ForeignKey(nameof(User_Id))]
        public User User { get; set; }

        [ForeignKey(nameof(Order_Id))]
        public Order Order { get; set; }
    }
}
