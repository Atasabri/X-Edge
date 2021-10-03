using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Orders.Interfaces;
using Xedge.Domain.Models;
using Xedge.Infrastructure.DTOs.Orders;
using Xedge.Infrastructure.Helpers;
using Xedge.Infrastructure.Pagination;
using Xedge.Repo.UnitOfWork;
using Xedge;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xedge.Resources;
using Xedge.Infrastructure.NotificationsHelpers;
using Xedge.Infrastructure.DashboardViewModels.Orders;
using Xedge.Business.Helpers;

namespace Xedge.Business.Services.Orders.Implementation
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NotificationHandler _notificationHandler;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public OrdersService(IUnitOfWork unitOfWork, NotificationHandler notificationHandler,
            IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._unitOfWork = unitOfWork;
            this._notificationHandler = notificationHandler;
            this._mapper = mapper;
            this._stringLocalizer = stringLocalizer;
        }
        public async Task<CreateState> AddOrderAsync(AddOrderDTO addOrderDTO)
        {
            var createState = new CreateState();
            // Get Current User Id
            var userId = await _unitOfWork.UsersRepository.GetCurrentUserId();
            addOrderDTO.User_Id = userId;

            var order = _mapper.Map<AddOrderDTO, Order>(addOrderDTO);
            if (order.OrderDetails.Any())
            {
                int productsWithZeroCostCount = 0;
                foreach (var orderDetailsItem in order.OrderDetails)
                {
                    if(orderDetailsItem.Quantity <= 0)
                    {
                        createState.ErrorMessages.Add(orderDetailsItem.Product_Id.ToString());
                        createState.ErrorMessages
                            .Add(_stringLocalizer["Please Add Quantity For Product '{0}'",
                            orderDetailsItem.Product_Id]);
                        return createState;

                    }
                    var product = await _unitOfWork.ProductsRepository.FindElementAsync(product =>
                                product.Id == orderDetailsItem.Product_Id );
                    if(product == null)
                    {
                        createState.ErrorMessages.Add(orderDetailsItem.Product_Id.ToString());
                        createState.ErrorMessages
                            .Add(_stringLocalizer["There Is No Product With Id '{0}'",
                            orderDetailsItem.Product_Id]);
                        return createState;
                    }
                    if(product.Price == 0)
                    {
                        productsWithZeroCostCount++;
                    }
                    if(productsWithZeroCostCount > Constants.MaxZeroItemsinOrder)
                    {
                        createState.ErrorMessages.Add(_stringLocalizer["You Can Order Only One Product With Zero Cost"]);
                        return createState;
                    }

                    orderDetailsItem.Price = product.Price;
                    order.SubTotal += orderDetailsItem.Price * orderDetailsItem.Quantity;
                }
                if(productsWithZeroCostCount > 0)
                {
                    double maxLimit;
                    bool hasMaxLimitForZeroWithCost = double.TryParse(await _unitOfWork.SettingsRepository.GetSettingValueUsingKeyAsync(Constants.LimitPriceForUseZeroWithCost), out maxLimit);
                    double maxLimitForZeroWithCost = hasMaxLimitForZeroWithCost ? maxLimit : Constants.DefaultLimitPriceForUseZeroWithCost;
                    if (order.SubTotal < maxLimitForZeroWithCost)
                    {
                        createState.ErrorMessages.Add(_stringLocalizer["To Order Zero With Cost Items You Must Order More Than {0} LE", maxLimitForZeroWithCost]);
                        return createState;
                    }
                }
            }
            else
            {
                createState.ErrorMessages.Add(_stringLocalizer["Your Cart Is Empty , Please Add Products"]);
                return createState;
            }

            if(order.SubTotal == 0)
            {
                createState.ErrorMessages.Add(_stringLocalizer["You Can Not Order Product With Zero Price Only !"]);
                return createState;
            }

            if(!string.IsNullOrEmpty(addOrderDTO.PromoCode))
            {
                var promoResult = await CheckPromoCodeAsync(addOrderDTO.PromoCode);
                if (promoResult.PromoCodeFound)
                {
                    order.Discount = (promoResult.DiscountPercent / 100) * order.SubTotal;
                }
                else
                {
                    createState.ErrorMessages.Add(_stringLocalizer["Can Not Found This Promo Code !"]);
                    return createState;
                }
            }

            // Get Taxs Value From DataBase and Assign to Order
            double taxs;
            bool hasTaxs = double.TryParse(await _unitOfWork.SettingsRepository.GetSettingValueUsingKeyAsync(Constants.TaxKey), out taxs);
            order.Taxs = hasTaxs ? taxs : Constants.DefaultTaxValue;
            // Calculate Final Order Total Price
            order.Total = (order.SubTotal - order.Discount) + order.Taxs;

            await _unitOfWork.OrdersRepository.CreateAsync(order);

            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                createState.CreatedSuccessfully = true;
                // Sending Notification To Admin Control Panel
                var orderViewModel = _mapper.Map<Order, ListingOrderViewModel>(order);
                var webNotificationState = new WebNotificationState("AddOrder", orderViewModel);
                await _unitOfWork.NotificationsRepository.WebNotifyToAllAsync(webNotificationState);
                createState.Id = order.Id;
            }
            else
            {
                createState.ErrorMessages.Add(_stringLocalizer["Can Not Create This Order !"]);
            }

            return createState;
        }

        public async Task<PromoCodeDTO> CheckPromoCodeAsync(string promoCode)
        {
            var promoCodeDTO = new PromoCodeDTO();
            if(!string.IsNullOrEmpty(promoCode))
            {
                var promoCodeItem = await _unitOfWork.PromoCodesRepository.FindElementAsync(promo =>
                     promo.Code == promoCode);
                if(promoCodeItem != null)
                {
                    promoCodeDTO.PromoCodeFound = true;
                    promoCodeDTO.DiscountPercent = promoCodeItem.DiscountPercent;
                }
            }
            return promoCodeDTO;
        }

        public async Task<PagedResult<ListingOrderDTO>> GetDriverOrdersAsync(PagingParameters pagingParameters)
        {
            // Get Current Driver Id
            var driverId = await _unitOfWork.UsersRepository.GetCurrentUserId();

            var orders = await _unitOfWork.OrdersRepository.GetElementsWithOrderAsync(order => order.Driver_Id == driverId && !order.Finished && !order.Closed,
                                  pagingParameters, order => order.DateTime,
                                  OrderingType.Descending, string.Format("{0}.{1}", nameof(Order.OrderStatuses), nameof(OrderStatus.Status)));

            var orderDTOs = orders.ToMappedPagedResult<Order, ListingOrderDTO>(_mapper);

            return orderDTOs;
        }

        public async Task<PagedResult<ListingOrderDTO>> GetDriverFinishedOrdersAsync(PagingParameters pagingParameters)
        {
            // Get Current Driver Id
            var driverId = await _unitOfWork.UsersRepository.GetCurrentUserId();

            var orders = await _unitOfWork.OrdersRepository.GetElementsWithOrderAsync(order => order.Driver_Id == driverId && (order.Finished || order.Closed),
                                  pagingParameters, order => order.DateTime,
                                  OrderingType.Descending, string.Format("{0}.{1}", nameof(Order.OrderStatuses), nameof(OrderStatus.Status)));

            var orderDTOs = orders.ToMappedPagedResult<Order, ListingOrderDTO>(_mapper);

            return orderDTOs;
        }

        public async Task<OrderDTO> GetOrderDetailsAsync(int orderId)
        {            
            // Get Current User Id
            var userId = await _unitOfWork.UsersRepository.GetCurrentUserId();
            // Get Order
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId &&
                              order.User_Id == userId,
                              string.Format("{0}.{1},{2}.{3}.{4},{5}"
                              , nameof(Order.OrderStatuses)
                              , nameof(OrderStatus.Status)
                              , nameof(Order.OrderDetails)
                              , nameof(OrderDetails.Product)
                              , nameof(OrderDetails.Product.Images)
                              , nameof(Order.Driver)));

            var orderDTO = _mapper.Map<Order, OrderDTO>(order);

            return orderDTO;
        }

        public async Task<OrderDTO> GetDriverOrderDetailsAsync(int orderId)
        {
            // Get Current Driver Id
            var driverId = await _unitOfWork.UsersRepository.GetCurrentUserId();
            // Get Order
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId &&
                              order.Driver_Id == driverId,
                              string.Format("{0}.{1},{2}.{3},{4}"
                              , nameof(Order.OrderStatuses)
                              , nameof(OrderStatus.Status)
                              , nameof(Order.OrderDetails)
                              , nameof(OrderDetails.Product)
                              , nameof(Order.User)
                              , nameof(Order.Driver)));

            var orderDTO = _mapper.Map<Order, OrderDTO>(order);

            return orderDTO;
        }

        public async Task<PagedResult<ListingOrderDTO>> GetOrdersAsync(PagingParameters pagingParameters)
        {
            // Get Current User Id
            var userId = await _unitOfWork.UsersRepository.GetCurrentUserId();

            var orders = await _unitOfWork.OrdersRepository.GetElementsWithOrderAsync(order => order.User_Id == userId,
                                  pagingParameters, order => order.DateTime,
                                  OrderingType.Descending, string.Format("{0}.{1}", nameof(Order.OrderStatuses), nameof(OrderStatus.Status)));

            var orderDTOs = orders.ToMappedPagedResult<Order, ListingOrderDTO>(_mapper);

            return orderDTOs;
        }

        public async Task<ActionState> StartOrderAsync(int orderId)
        {
            var actionState = new ActionState();
            string currentDriverId = await _unitOfWork.UsersRepository.GetCurrentUserId();
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId && order.Driver_Id == currentDriverId);
            if (order == null)
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Can Not Start Order"]);
                return actionState;
            }
            order.Started = true;
            order.Start_Date = DateTimeProvider.GetEgyptDateTime();
            _unitOfWork.OrdersRepository.Update(order);
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                await _notificationHandler.NotifyUserOrderAsync(orderId, "Your order '{0}' has been delivered");
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add(_stringLocalizer["Can Not Start Order"]);
            return actionState;
        }

        public async Task<ActionState> FinishOrderAsync(int orderId)
        {
            var actionState = new ActionState();
            string currentDriverId = await _unitOfWork.UsersRepository.GetCurrentUserId();
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId && order.Driver_Id == currentDriverId);
            if (order == null)
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Can Not Start Order"]);
                return actionState;
            }
            order.Finished = true;
            order.Finish_Date = DateTimeProvider.GetEgyptDateTime();
            _unitOfWork.OrdersRepository.Update(order);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                await _notificationHandler.NotifyUserOrderAsync(orderId, "Your Order '{0}' has been completed");
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add(_stringLocalizer["Can Not Finish Order"]);
            return actionState;
        }
    }
}
