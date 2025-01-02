using Evimden.BusinessLayer.Interfaces.CargoInterfaces;
using Evimden.BusinessLayer.Interfaces.CloudServiceInterfaces;
using Evimden.BusinessLayer.Interfaces.IdentityInterfaces;
using Evimden.BusinessLayer.Interfaces.LocationInterfaces;
using Evimden.BusinessLayer.Interfaces.OrderInterfaces;
using Evimden.BusinessLayer.Interfaces.ProductInterfaces;
using Evimden.BusinessLayer.Mapper;
using Evimden.BusinessLayer.Services.CargoServices;
using Evimden.BusinessLayer.Services.CloudServices;
using Evimden.BusinessLayer.Services.IdentityServices;
using Evimden.BusinessLayer.Services.LocationServices;
using Evimden.BusinessLayer.Services.OrderServices;
using Evimden.BusinessLayer.Services.ProductServices;
using Evimden.CoreLayer.Concrete.IdentityEntities;
using Evimden.CoreLayer.Repository;
using Evimden.DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evimden.BusinessLayer.DependencyInjection
{
    public static class ServiceRegistrationForWebUi
    {
        public static void AddBusinessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Unit Of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // AutoMapper
            services.AddAutoMapper(typeof(MapProfile));

            // Evimden Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IProductApprovalService, ProductApprovelService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            // Identity Services
            services.AddScoped<UserManager<CustomUser>>();
            services.AddScoped<RoleManager<CustomRole>>();

            // Cloud
            services.AddSingleton<ICloudStorageService, CloudStorageService>();
        }
    }
}