using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Infrastructure.DTOs.Wallet;
using Xedge.Infrastructure.Helpers;

namespace Xedge.Business.Services.Wallet.Interfaces
{
    public interface IWalletTransactionsService
    {
        /// <summary>
        /// Get Current User Wallet Balance Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<double> GetBalanceAsync();
        /// <summary>
        /// Adding New Wallet Deposit Transaction Asynchronous
        /// </summary>
        /// <param name="addTransactionDTO"></param>
        /// <returns></returns>
        Task<CreateState> AddDepositTransactionAsync(AddTransactionDTO addTransactionDTO);
        /// <summary>
        /// Adding New Wallet Pull Transaction Asynchronous
        /// </summary>
        /// <param name="addTransactionDTO"></param>
        /// <returns></returns>
        Task<CreateState> AddPullTransactionAsync(AddTransactionDTO addTransactionDTO);
    }
}
