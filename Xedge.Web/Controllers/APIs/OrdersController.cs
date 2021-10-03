using Xedge.Business.Services.Orders.Interfaces;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.DTOs.Orders;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.APIs
{
    public class OrdersController : AuthorizedAPIController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this._ordersService = ordersService;
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderDTO addOrderDTO)
        {
            var result = await _ordersService.AddOrderAsync(addOrderDTO);
            if (result.CreatedSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _ordersService.GetOrdersAsync(pagingParameters));
        }

        [HttpGet("GetOrder/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            return Ok(await _ordersService.GetOrderDetailsAsync(orderId));
        }

        [HttpPost("CheckCode/{code}")]
        public async Task<IActionResult> CheckCode(string code)
        {
            return Ok(await _ordersService.CheckPromoCodeAsync(code));
        }
    }
}
