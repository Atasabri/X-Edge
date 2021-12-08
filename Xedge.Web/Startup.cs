using AutoMapper;
using Xedge.Business.Mapping;
using Xedge.Business.Services.Categories.Implementation;
using Xedge.Business.Services.Categories.Interfaces;
using Xedge.Business.Services.Identity.Implementation;
using Xedge.Business.Services.Identity.Interfaces;
using Xedge.Business.Services.Identity.Implementation.Dashboard;
using Xedge.Business.Services.Identity.Interfaces.Dashboard;
using Xedge.Business.Services.Notifications.Implementation;
using Xedge.Business.Services.Notifications.Interfaces;
using Xedge.Business.Services.Offers.Implementation;
using Xedge.Business.Services.Offers.Interfaces;
using Xedge.Business.Services.Orders.Implementation;
using Xedge.Business.Services.Orders.Interfaces;
using Xedge.Business.Services.Products.Implementation;
using Xedge.Business.Services.Products.Interfaces;
using Xedge.Business.Services.Search.Implementation;
using Xedge.Business.Services.Search.Interfaces;
using Xedge.Business.Services.Sliders.Implementation;
using Xedge.Business.Services.Sliders.Interfaces;
using Xedge.Business.Services.User.Implementation;
using Xedge.Business.Services.User.Interfaces;
using Xedge.Business.Services.User.Implementation.Dashboard;
using Xedge.Business.Services.User.Interfaces.Dashboard;
using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Infrastructure.BaseService;
using Xedge.Infrastructure.Helpers;
using Xedge.Repo.UnitOfWork;
using Xedge.Resources.Localization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Xedge.Business.Services.Categories.Interfaces.Dashboard;
using Xedge.Business.Services.Categories.Implementation.Dashboard;
using Xedge.Business.Services.Brands.Implementation;
using Xedge.Business.Services.Brands.Interfaces;
using Xedge.Business.Services.Markets.Implementation;
using Xedge.Business.Services.Markets.Interfaces;
using Xedge.Business.Services.Brands.Interfaces.Dashboard;
using Xedge.Business.Services.Brands.Implementation.Dashboard;
using Xedge.Business.Services.Markets.Interfaces.Dashboard;
using Xedge.Business.Services.Sliders.Interfaces.Dashboard;
using Xedge.Business.Services.Offers.Interfaces.Dashboard;
using Xedge.Business.Services.Markets.Implementation.Dashboard;
using Xedge.Business.Services.Sliders.Implementation.Dashboard;
using Xedge.Business.Services.Offers.Implementation.Dashboard;
using Xedge.Business.Services.PromoCodes.Interfaces.Dashboard;
using Xedge.Business.Services.PromoCodes.Implementation.Dashboard;
using Xedge.Business.Services.Statuses.Interfaces.Dashboard;
using Xedge.Business.Services.Statuses.Implementation.Dashboard;
using Xedge.Business.Services.Products.Implementation.Dashboard;
using Xedge.Business.Services.Products.Interfaces.Dashboard;
using Xedge.Business.Services.Orders.Interfaces.Dashboard;
using Xedge.Business.Services.Orders.Implementation.Dashboard;
using Xedge.Infrastructure.Hubs;
using Xedge.Business.Services.Verification.Interfaces;
using Xedge.Business.Services.Verification.Implementation;
using Xedge.Infrastructure.AppSettings;
using Xedge.Resources;
using Xedge.Business.Services.Settings.Interfaces.Dashboard;
using Xedge.Business.Services.Settings.Implementation.Dashboard;
using Xedge.Business.Helpers;
using Xedge.Business.Services.Settings.Implementation;
using Xedge.Business.Services.Settings.Interfaces;
using Xedge.Business.Services.Search.Implementation.Dashboard;
using Xedge.Business.Services.Search.Interfaces.Dashboard;
using Xedge.Business.Services.News.Interfaces;
using Xedge.Business.Services.News.Implementation;
using Xedge.Business.Services.Videos.Interfaces;
using Xedge.Business.Services.Videos.Implementation;
using Xedge.Business.Services.Files.Interfaces;
using Xedge.Business.Services.Files.Implementation;
using Xedge.Business.Services.Wallet.Interfaces;
using Xedge.Business.Services.Wallet.Implementation;
using Xedge.Business.Services.News.Interfaces.Dashboard;
using Xedge.Business.Services.News.Implementation.Dashboard;
using Xedge.Business.Services.Videos.Interfaces.Dashboard;
using Xedge.Business.Services.Videos.Implementation.Dashboard;
using Xedge.Business.Services.Files.Interfaces.Dashboard;
using Xedge.Business.Services.Files.Implementation.Dashboard;

namespace Xedge.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddSignalR();
            //Adding Localization Service
            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });

            //Add Mvc To Dependency Injection Container With Localization Pipline Middleware Attribute
            services.AddControllersWithViews()
                    .AddViewLocalization(opts => { opts.ResourcesPath = "Resources"; })
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization(options => {
                        options.DataAnnotationLocalizerProvider = (type, factory) =>
                            factory.Create(typeof(SharedResource));
                    });



            // Localization Configuration
            var supportedCultures = new[]
                         {
                          new CultureInfo("en"),
                          new CultureInfo("ar"),
                         };

            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            options.RequestCultureProviders = new[]
            {
                 new RouteDataRequestCultureProvider() { Options = options }
            };
            services.AddSingleton(options);


            //Adding Default System Identity
            services.AddIdentity<User, IdentityRole>()
                .AddErrorDescriber<LocalizedIdentityErrorDescriber>()
                .AddEntityFrameworkStores<DB>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Xedge", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization Header Using The Bearer Scheme. \r\n\r\n 
                      Enter 'Bearer' [space] And Ahen Your Token in The Text Input Below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                     {
                         new OpenApiSecurityScheme
                         {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                         },
                         new List<string>()
                     }
                });
            });

            //############### Adding Authentication And Authorization Service ##################
            // Adding Authentication  
            services.AddAuthentication()
            .AddCookie(options => options.SlidingExpiration = true)

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Constants.Audiance,
                    ValidIssuer = Constants.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret))
                };
            });

            // Configure CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IDriverAuthenticationService, DriverAuthenticationService>();
            services.AddTransient<IVerificationService, VerificationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<INotificationsService, NotificationsService>();
            services.AddTransient<IFavoritesService, FavoritesService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IPaymentMethodsService, PaymentMethodsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IOffersService, OffersService>();
            services.AddTransient<ISlidersService, SlidersService>();
            services.AddTransient<IBrandsService, BrandsService>();
            services.AddTransient<IMarketsService, MarketsService>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IVideosService, VideosService>();
            services.AddTransient<IFilesService, FilesService>();
            services.AddTransient<IWalletTransactionsService, WalletTransactionsService>();


            // Dashboard Dpendency Injection
            services.AddTransient<IDashboardAuthenticationService, DashboardAuthenticationService>();
            services.AddTransient<IDashboardUserService, DashboardUserService>();
            services.AddTransient<IDashboardDriverService, DashboardDriverService>();
            services.AddTransient<IDashboardCategoriesService, DashboardCategoriesService>();
            services.AddTransient<IDashboardSubCategoriesService, DashboardSubCategoriesService>();
            services.AddTransient<IDashboardBrandsService, DashboardBrandsService>();
            services.AddTransient<IDashboardMarketsService, DashboardMarketsService>();
            services.AddTransient<IDashboardSlidersService, DashboardSlidersService>();
            services.AddTransient<IDashboardOffersService, DashboardOffersService>();
            services.AddTransient<IDashboardPromoCodeService, DashboardPromoCodeService>();
            services.AddTransient<IDashboardStatusesService, DashboardStatusesService>();
            services.AddTransient<IDashboardProductsService, DashboardProductsService>();
            services.AddTransient<IDashboardOrdersService, DashboardOrdersService>();
            services.AddTransient<IDashboardSettingsService, DashboardSettingsService>();
            services.AddTransient<IDashboardSearchService, DashboardSearchService>();
            services.AddTransient<IDashboardNewsService, DashboardNewsService>();
            services.AddTransient<IDashboardVideosService, DashboardVideosService>();
            services.AddTransient<IDashboardFilesService, DashboardFilesService>();
            services.AddTransient<IDashboardFilesCategoryService, DashboardFilesCategoryService>();

            services.AddTransient<AuthenticationHandler>();
            services.AddTransient<NotificationHandler>();

            services.AddHttpContextAccessor();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DB>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Xedge");
                c.RoutePrefix = "api";
            });

            // Add Localization Middleware
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);


            app.UseRouting();

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<RealTimeHub>("/RealTimeData");
            });
        }
    }
}
