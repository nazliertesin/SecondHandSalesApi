using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PycApi.Service;
using SecondhandSalesApi.Mapper;
using Service;

namespace SecondhandSalesApi.StartUpExtension
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            // services 
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISoldService, SoldService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITokenService, TokenService>();


            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
