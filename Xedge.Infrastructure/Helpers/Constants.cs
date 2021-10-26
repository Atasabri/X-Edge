﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Infrastructure.Helpers
{
    public static class Constants
    {
        // Identity Service
        public const string Issuer = Audiance;
        public const string Audiance = "https://localhost:64837/";
        public const string Secret = "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM";

        // User Role
        public const string UserRoleName = "User";
        // Driver Role
        public const string DriverRoleName = "Driver";

        // X-Edge Offer
        public const int XedgeOfferId = 1;
        public const string XedgeOfferName = "X-Edge Offers";
        public const string XedgeOfferName_Ar = "عروض متجرنا";

        // Paging Max Size
        public const int MaxPageSize = 10;

        // Max Zero Cost Items in Ordrer
        public const int MaxZeroItemsinOrder = 1;

        // Delivery Key Name & Value
        public const string DeliveryKeyName = "Delivery";
        public const string DeliveryKey = "Delivery";
        public const double DefaultDeliveryValue = 5;
        // Visa Available Key Name & Value
        public const string VisaAvailableKeyName = "Visa Available";
        public const string VisaAvailable = "VisaAvailable";
        public const bool DefaultVisaAvailable = true;
        // Limit Price For Use Zero With Cost Key Name & Value
        public const string LimitPriceForUseZeroWithCostName = "Limit Price For Use Zero With Cost";
        public const string LimitPriceForUseZeroWithCost = "LimitPriceForUseZeroWithCost";
        public const double DefaultLimitPriceForUseZeroWithCost = 300;
    }
}
