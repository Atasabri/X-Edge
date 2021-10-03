using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.DTOs.Wallet
{
    public class WalletTransactionDTO : BaseDTO
    {
        public DateTime Date { get; set; }
        public double Money { get; set; }
    }
}
