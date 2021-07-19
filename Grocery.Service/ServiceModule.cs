using Grocery.Service.CustomerServices;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Grocery.Service
{
    public static class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
          
        }
    }
}
