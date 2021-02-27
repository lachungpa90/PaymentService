using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentAPI.Data;
using PaymentAPI.Interfaces;
using PaymentAPI.Services;

namespace PaymentAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddScoped<IPremiumPaymentService, PremimumPaymentService>();
            services.AddScoped<IPaymentChargeHandler, PaymentChargeHandler>();
            services.AddScoped<IEntityHelper, EntityHelper>();
            return services;
        }
    }
}
