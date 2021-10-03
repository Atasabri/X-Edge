using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Wallet;

namespace Xedge.Repo.Repositories.Implementation.Wallet
{
    public class WalletTransactionsRepository : GenericRepository<WalletTransaction>, IWalletTransactionsRepository
    {
        public WalletTransactionsRepository(DB context)
    : base(context)
        {
        }
    }
}
