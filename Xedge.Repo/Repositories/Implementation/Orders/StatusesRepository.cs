using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Repo.Repositories.Implementation.Orders
{
    public class StatusesRepository : GenericRepository<Statuses>, IStatusesRepository
    {
        public StatusesRepository(DB context)
            : base(context)
        {
        }
    }
}
