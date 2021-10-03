using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.PromoCodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Repo.Repositories.Implementation.PromoCodes
{
    public class PromoCodesRepository : GenericRepository<PromoCode>, IPromoCodesRepository
    {
        public PromoCodesRepository(DB context)
            : base(context)
        {
        }
    }
}
