﻿using Xedge.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Xedge.Domain.Models
{
    public class Statuses : BaseNamedModel
    {
        [InverseProperty(property: nameof(OrderStatus.Status))]
        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }
    }
}
