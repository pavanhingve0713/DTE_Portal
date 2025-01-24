using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Infrastructure.Contract;
using HRMS.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HRMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDropDowns, DropDowns>();

            return services;
        }
    }
}
