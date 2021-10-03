using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Repo.Repositories.Interfaces.Orders
{
    public interface IOrderStatusesRepository : IGenericRepository<OrderStatus>
    {
        /// <summary>
        /// Check If Status Id Added Before For Order Id in Order Statuses Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        Task<bool> CheckOrderStatusAddedBeforeAsync(int orderId, int statusId);
    }
}
