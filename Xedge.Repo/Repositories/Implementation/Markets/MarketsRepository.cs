using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Markets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Repo.Repositories.Implementation.Markets
{
    public class MarketsRepository : GenericRepository<Market>, IMarketsRepository
    {
        public MarketsRepository(DB context)
            : base(context)
        {
        }
    }
}
