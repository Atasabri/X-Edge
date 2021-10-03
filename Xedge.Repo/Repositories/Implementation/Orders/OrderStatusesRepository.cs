﻿using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Repo.Repositories.Implementation.Orders
{
    public class OrderStatusesRepository : GenericRepository<OrderStatus>, IOrderStatusesRepository
    {
        public OrderStatusesRepository(DB context)
            : base(context)
        {
        }

        public async Task<bool> CheckOrderStatusAddedBeforeAsync(int orderId, int statusId)
        {
            return await _entities.AnyAsync(status => status.Status_Id == statusId && status.Order_Id == orderId);
        }
    }
}
