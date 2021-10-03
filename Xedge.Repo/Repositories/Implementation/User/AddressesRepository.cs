using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Repo.Repositories.Implementation.User
{
    public class AddressesRepository : GenericRepository<Address>, IAddressesRepository
    {
        public AddressesRepository(DB context)
            : base(context)
        {
        }
    }
}
