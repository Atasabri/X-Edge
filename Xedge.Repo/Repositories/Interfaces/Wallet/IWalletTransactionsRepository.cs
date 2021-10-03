using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;

namespace Xedge.Repo.Repositories.Interfaces.Wallet
{
    public interface IWalletTransactionsRepository : IGenericRepository<WalletTransaction>
    {
    }
}
