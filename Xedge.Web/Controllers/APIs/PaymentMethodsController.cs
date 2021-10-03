﻿using Xedge.Business.Services.User.Interfaces;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.DTOs.User.Address;
using Xedge.Infrastructure.DTOs.User.PaymentMethods;
using Xedge.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xedge.Web.Controllers.APIs
{
    public class PaymentMethodsController : AuthorizedAPIController
    {
        private readonly IPaymentMethodsService _paymentMethodsService;
        public PaymentMethodsController(IPaymentMethodsService paymentMethodsService)
        {
            this._paymentMethodsService = paymentMethodsService;
        }

        [HttpGet("GetPaymentMethods")]
        public async Task<IActionResult> GetPaymentMethods([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _paymentMethodsService.GetUserPaymentMethodsAsync(pagingParameters));
        }

        [HttpPost("AddPaymentMethod")]
        public async Task<IActionResult> AddPaymentMethod([FromBody] AddPaymentMethodDTO addPaymentMethodDTO)
        {
            var result = await _paymentMethodsService.AddPaymentMethodAsync(addPaymentMethodDTO);
            if (result.CreatedSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeletePaymentMethod")]
        public async Task<IActionResult> DeletePaymentMethod(DeletePaymentMethodDTO deletePaymentMethodDTO)
        {
            var result = await _paymentMethodsService.RemovePaymentMethodAsync(deletePaymentMethodDTO);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
