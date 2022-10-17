using HYF.Lesson5.ClassLibrary.Models;
using HYF.Lesson5.ClassLibrary.Services;
using HYF.Lesson5.ClassLibrary.Services.Interfaces;

namespace HYF.Lesson5.WebshopAPI.Models
{
    public static class ServiceExtensions
    {
        public static void AddWebshopServices(this IServiceCollection services)
        {
            services.AddTransient<WebShop>();
            services.AddTransient<IShippingCompany, BPost>();
            services.AddTransient<IPaymentService, MasterCardService>();
        }
    }
}
