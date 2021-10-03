using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Wallet;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void WalletMapping()
        {
            CreateMap<WalletTransaction, WalletTransactionDTO>()
                   .ReverseMap();

            CreateMap<AddTransactionDTO, WalletTransaction>()
                   .ReverseMap();
        }

        void DashboardWalletMapping()
        {

        }
    }
}
