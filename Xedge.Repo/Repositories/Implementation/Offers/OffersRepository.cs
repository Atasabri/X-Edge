using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Offers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Repo.Repositories.Implementation.Offers
{
    public class OffersRepository : GenericRepository<Offer>, IOffersRepository
    {
        public OffersRepository(DB context)
    : base(context)
        {
        }
    }
}
