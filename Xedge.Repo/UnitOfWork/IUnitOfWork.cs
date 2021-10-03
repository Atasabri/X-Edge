using Xedge.Repo.Repositories.Interfaces.Brands;
using Xedge.Repo.Repositories.Interfaces.Categories;
using Xedge.Repo.Repositories.Interfaces.SystemFiles;
using Xedge.Repo.Repositories.Interfaces.Markets;
using Xedge.Repo.Repositories.Interfaces.Notifications;
using Xedge.Repo.Repositories.Interfaces.Offers;
using Xedge.Repo.Repositories.Interfaces.Orders;
using Xedge.Repo.Repositories.Interfaces.Products;
using Xedge.Repo.Repositories.Interfaces.PromoCodes;
using Xedge.Repo.Repositories.Interfaces.Settings;
using Xedge.Repo.Repositories.Interfaces.Sliders;
using Xedge.Repo.Repositories.Interfaces.SMSCodes;
using Xedge.Repo.Repositories.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Repo.Repositories.Interfaces.News;
using Xedge.Repo.Repositories.Interfaces.Videos;
using Xedge.Repo.Repositories.Interfaces.Files;
using Xedge.Repo.Repositories.Interfaces.Wallet;

namespace Xedge.Repo.UnitOfWork
{
    public interface IUnitOfWork
    {

        // Brands Repositories
        IBrandsRepository BrandsRepository{ get; }

        // Sliders Repositories
        ISlidersRepository SlidersRepository { get; }

        // Categories Repositories
        ICategoriesRepository CategoriesRepository { get; }
        ISubCategoriesRepository SubCategoriesRepository { get; }

        // Offers Repositories
        IOffersRepository OffersRepository { get; }


        // Markets Repositories
        IMarketsRepository MarketsRepository { get; }


        //Notifications Repositories
        INotificationsRepository NotificationsRepository { get; }


        // Orders Repositories
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        IOrderStatusesRepository OrderStatusesRepository { get; }
        IStatusesRepository StatusesRepository { get; }


        //Products Repositories
        IProductsRepository ProductsRepository { get; }
        IProductImagesRepository ProductImagesRepository { get; }

        // Promo Codes Repositories
        IPromoCodesRepository PromoCodesRepository { get; }


        // User Repositories
        IAddressesRepository AddressesRepository { get; }
        IFavoritesRepository FavoritesRepository { get; }
        IPaymentMethodsRepository PaymentMethodsRepository { get; }
        IUsersRepository UsersRepository { get; }


        // Files Repositories
        ISystemFilesRepository SystemFilesRepository { get; }

        // Settings Repositories
        ISettingsRepository SettingsRepository { get; }

        // Verification Repositories
        ISMSCodeRepository SMSCodeRepository { get; }


        INewsRepository NewsRepository { get; }
        INewsImagesRepository NewsImagesRepository { get; }
        IVideosRepository VideosRepository { get; }
        IFilesRepository FilesRepository { get; }
        IWalletTransactionsRepository WalletTransactionsRepository { get; }



        /// <summary>
        /// Save Changes To Database
        /// </summary>
        int Save();
        /// <summary>
        /// Save Changes To Database Asynchronous
        /// </summary>
        Task<int> SaveAsync();
    }
}
