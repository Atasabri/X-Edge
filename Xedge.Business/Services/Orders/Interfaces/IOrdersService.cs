﻿using Xedge.Infrastructure.DTOs.Orders;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Business.Services.Orders.Interfaces
{
    public interface IOrdersService
    {
        /// <summary>
        /// Create Order Using All Order Details And Promo Code Asynchronous
        /// </summary>
        /// <param name="addOrderDTO"></param>
        /// <returns></returns>
        Task<CreateState> AddOrderAsync(AddOrderDTO addOrderDTO);
        /// <summary>
        /// Get Current Logined User Orders (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingOrderDTO>> GetOrdersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Current Logined Driver Orders (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingOrderDTO>> GetDriverOrdersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Current Logined Driver Finished Orders (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingOrderDTO>> GetDriverFinishedOrdersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Order All Details Using Order Id & Current User Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderDTO> GetOrderDetailsAsync(int orderId);
        /// <summary>
        /// Get Order All Details Using Order Id & Current Driver Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task<OrderDTO> GetDriverOrderDetailsAsync(int orderId);

        /// <summary>
        /// Return Discount Of Promo Code If Found Asynchronous
        /// </summary>
        /// <param name="promoCode"></param>
        /// <returns></returns>
        Task<PromoCodeDTO> CheckPromoCodeAsync(string promoCode);
        /// <summary>
        /// Make Order Started Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<ActionState> StartOrderAsync(int orderId);
        /// <summary>
        /// Make Order Finished Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<ActionState> FinishOrderAsync(int orderId);
    }
}
