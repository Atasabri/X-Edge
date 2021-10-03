using AutoMapper;
using Xedge.Domain.Models.BaseModels;
using Xedge.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Xedge.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        private string localizedName
        {
            get
            {
                return CultureInfo.CurrentCulture.Name == "ar" ? "Name_AR" : "Name";
            }
        }
        private string localizedTitle
        {
            get
            {
                return CultureInfo.CurrentCulture.Name == "ar" ? "Title_AR" : "Title";
            }
        }
        private string localizedDescription
        {
            get
            {
                return CultureInfo.CurrentCulture.Name == "ar" ? "Description_AR" : "Description";
            }
        }

        public AutoMapperProfile()
        {
            CategoriesMapping();
            ProductsMapping();
            UsersMapping();
            NotificationsMapping();
            OrdersMapping();
            OffersMapping();
            SlidersMapping();
            BrandsMapping();
            MarketsMapping();
            NewsMapping();
            VideosMapping();
            FilesMapping();
            WalletMapping();

            // Dashboard Mapping
            DashboardUsersMapping();
            DashboardCategoriesMapping();
            DashboardBrandsMapping();
            DashboardMarketsMapping();
            DashboardSlidersMapping();
            DashboardOffersMapping();
            DashboardPromoCodesMapping();
            DashboardStatusesMapping();
            DashboardProductsMapping();
            DashboardOrdersMapping();
            DashboardSettingsMapping();
            DashboardNewsMapping();
            DashboardVideosMapping();
            DashboardFilesMapping();
            DashboardWalletMapping();
        }
    }
}
