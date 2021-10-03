using Xedge.Repo.Repositories.Interfaces.Brands;
using Xedge.Repo.Repositories.Interfaces.Categories;
using Xedge.Repo.Repositories.Interfaces.Markets;
using Xedge.Repo.Repositories.Interfaces.Notifications;
using Xedge.Repo.Repositories.Interfaces.Orders;
using Xedge.Repo.Repositories.Interfaces.Products;
using Xedge.Repo.Repositories.Interfaces.PromoCodes;
using Xedge.Repo.Repositories.Interfaces.User;
using Xedge.Repo.Repositories.Implementation.Brands;
using Xedge.Repo.Repositories.Implementation.Categories;
using Xedge.Repo.Repositories.Implementation.Markets;
using Xedge.Repo.Repositories.Implementation.Notifications;
using Xedge.Repo.Repositories.Implementation.Orders;
using Xedge.Repo.Repositories.Implementation.Products;
using Xedge.Repo.Repositories.Implementation.PromoCodes;
using Xedge.Repo.Repositories.Implementation.User;
using Xedge.Domain.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Xedge.Domain.Models;
using Xedge.Repo.Repositories.Interfaces.Offers;
using Xedge.Repo.Repositories.Implementation.Offers;
using Xedge.Repo.Repositories.Interfaces.Sliders;
using Xedge.Repo.Repositories.Implementation.Sliders;
using Xedge.Repo.Repositories.Interfaces.SystemFiles;
using Xedge.Repo.Repositories.Implementation.SystemFiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Xedge.Infrastructure.Hubs;
using Microsoft.Extensions.Options;
using Xedge.Infrastructure.AppSettings;
using Xedge.Repo.Repositories.Interfaces.Settings;
using Xedge.Repo.Repositories.Implementation.Settings;
using Xedge.Repo.Repositories.Interfaces.SMSCodes;
using Xedge.Repo.Repositories.Implementation.SMSCodes;
using Xedge.Repo.Repositories.Interfaces.News;
using Xedge.Repo.Repositories.Interfaces.Files;
using Xedge.Repo.Repositories.Interfaces.Videos;
using Xedge.Repo.Repositories.Interfaces.Wallet;
using Xedge.Repo.Repositories.Implementation.News;
using Xedge.Repo.Repositories.Implementation.Files;
using Xedge.Repo.Repositories.Implementation.Videos;
using Xedge.Repo.Repositories.Implementation.Wallet;

namespace Xedge.Repo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DB _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<User> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHubContext<RealTimeHub> _hubContext;
        private readonly AppSettings _appSettings;

        IBrandsRepository brandsRepository;
        ISlidersRepository slidersRepository;
        ICategoriesRepository categoriesRepository;
        ISubCategoriesRepository subCategoriesRepository;
        IOffersRepository offersRepository;
        IMarketsRepository marketsRepository;
        INotificationsRepository notificationsRepository;
        IOrderDetailsRepository orderDetailsRepository;
        IOrdersRepository ordersRepository;
        IOrderStatusesRepository orderStatusesRepository;
        IStatusesRepository statusesRepository;
        IProductsRepository productsRepository;
        IProductImagesRepository productImagesRepository;
        IPromoCodesRepository promoCodesRepository;
        IAddressesRepository addressesRepository;
        IFavoritesRepository favoritesRepository;
        IPaymentMethodsRepository paymentMethodsRepository;
        IUsersRepository usersRepository;
        ISystemFilesRepository systemFilesRepository;
        ISettingsRepository settingsRepository;
        ISMSCodeRepository smsCodeRepository;


        INewsRepository  newsRepository;
        INewsImagesRepository newsImagesRepository;
        IFilesRepository filesRepository;
        IVideosRepository videosRepository;
        IWalletTransactionsRepository walletTransactionsRepository;


        public IBrandsRepository BrandsRepository
        {
            get
            {
                if (brandsRepository == null)
                {
                    brandsRepository = new BrandsRepository(_context);
                }
                return brandsRepository;
            }
        }

        public ISlidersRepository SlidersRepository
        {
            get
            {
                if (slidersRepository == null)
                {
                    slidersRepository = new SlidersRepository(_context);
                }
                return slidersRepository;
            }
        }

        public ICategoriesRepository CategoriesRepository
        {
            get
            {
                if (categoriesRepository == null)
                {
                    categoriesRepository = new CategoriesRepository(_context);
                }
                return categoriesRepository;
            }
        }

        public ISubCategoriesRepository SubCategoriesRepository
        {
            get
            {
                if (subCategoriesRepository == null)
                {
                    subCategoriesRepository = new SubCategoriesRepository(_context);
                }
                return subCategoriesRepository;
            }
        }

        public IOffersRepository OffersRepository
        {
            get
            {
                if (offersRepository == null)
                {
                    offersRepository = new OffersRepository(_context);
                }
                return offersRepository;
            }
        }

        public IMarketsRepository MarketsRepository
        {
            get
            {
                if (marketsRepository == null)
                {
                    marketsRepository = new MarketsRepository(_context);
                }
                return marketsRepository;
            }
        }

        public INotificationsRepository NotificationsRepository
        {
            get
            {
                if (notificationsRepository == null)
                {
                    notificationsRepository = new NotificationsRepository(_context, _appSettings, _hubContext);
                }
                return notificationsRepository;
            }
        }

        public IOrderDetailsRepository OrderDetailsRepository
        {
            get
            {
                if (orderDetailsRepository == null)
                {
                    orderDetailsRepository = new OrderDetailsRepository(_context);
                }
                return orderDetailsRepository;
            }
        }

        public IOrdersRepository OrdersRepository
        {
            get
            {
                if (ordersRepository == null)
                {
                    ordersRepository = new OrdersRepository(_context);
                }
                return ordersRepository;
            }
        }

        public IOrderStatusesRepository OrderStatusesRepository
        {
            get
            {
                if (orderStatusesRepository == null)
                {
                    orderStatusesRepository = new OrderStatusesRepository(_context);
                }
                return orderStatusesRepository;
            }
        }

        public IStatusesRepository StatusesRepository
        {
            get
            {
                if (statusesRepository == null)
                {
                    statusesRepository = new StatusesRepository(_context);
                }
                return statusesRepository;
            }
        }

        public IProductsRepository ProductsRepository
        {
            get
            {
                if (productsRepository == null)
                {
                    productsRepository = new ProductsRepository(_context);
                }
                return productsRepository;
            }
        }

        public IProductImagesRepository ProductImagesRepository
        {
            get
            {
                if (productImagesRepository == null)
                {
                    productImagesRepository = new ProductImagesRepository(_context);
                }
                return productImagesRepository;
            }
        }

        public IPromoCodesRepository PromoCodesRepository
        {
            get
            {
                if (promoCodesRepository == null)
                {
                    promoCodesRepository = new PromoCodesRepository(_context);
                }
                return promoCodesRepository;
            }
        }

        public IAddressesRepository AddressesRepository
        {
            get
            {
                if (addressesRepository == null)
                {
                    addressesRepository = new AddressesRepository(_context);
                }
                return addressesRepository;
            }
        }

        public IFavoritesRepository FavoritesRepository
        {
            get
            {
                if (favoritesRepository == null)
                {
                    favoritesRepository = new FavoritesRepository(_context);
                }
                return favoritesRepository;
            }
        }

        public IPaymentMethodsRepository PaymentMethodsRepository
        {
            get
            {
                if (paymentMethodsRepository == null)
                {
                    paymentMethodsRepository = new PaymentMethodsRepository(_context);
                }
                return paymentMethodsRepository;
            }
        }

        public IUsersRepository UsersRepository
        {
            get
            {
                if (usersRepository == null)
                {
                    usersRepository = new UsersRepository(_accessor, _userManager);
                }
                return usersRepository;
            }
        }

        public ISystemFilesRepository SystemFilesRepository
        {
            get
            {
                if (systemFilesRepository == null)
                {
                    systemFilesRepository = new SystemFilesRepository(_hostingEnvironment);
                }
                return systemFilesRepository;
            }
        }

        public ISettingsRepository SettingsRepository
        {
            get
            {
                if (settingsRepository == null)
                {
                    settingsRepository = new SettingsRepository(_context);
                }
                return settingsRepository;
            }
        }

        public ISMSCodeRepository SMSCodeRepository
        {
            get
            {
                if (smsCodeRepository == null)
                {
                    smsCodeRepository = new SMSCodeRepository(_context);
                }
                return smsCodeRepository;
            }
        }

        public INewsRepository NewsRepository
        {
            get
            {
                if (newsRepository == null)
                {
                    newsRepository = new NewsRepository(_context);
                }
                return newsRepository;
            }
        }

        public INewsImagesRepository NewsImagesRepository
        {
            get
            {
                if (newsImagesRepository == null)
                {
                    newsImagesRepository = new NewsImagesRepository(_context);
                }
                return newsImagesRepository;
            }
        }

        public IFilesRepository FilesRepository
        {
            get
            {
                if (filesRepository == null)
                {
                    filesRepository = new FilesRepository(_context);
                }
                return filesRepository;
            }
        }

        public IVideosRepository VideosRepository
        {
            get
            {
                if (videosRepository == null)
                {
                    videosRepository = new VideosRepository(_context);
                }
                return videosRepository;
            }
        }

        public IWalletTransactionsRepository WalletTransactionsRepository
        {
            get
            {
                if (walletTransactionsRepository == null)
                {
                    walletTransactionsRepository = new WalletTransactionsRepository(_context);
                }
                return walletTransactionsRepository;
            }
        }


        public UnitOfWork(DB context, IHttpContextAccessor accessor,
            UserManager<User> userManager,
            IHostingEnvironment hostingEnvironment,
            IHubContext<RealTimeHub> hubContext,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            this._accessor = accessor;
            this._userManager = userManager;
            this._hostingEnvironment = hostingEnvironment;
            this._hubContext = hubContext;
            this._appSettings = appSettings.Value;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
