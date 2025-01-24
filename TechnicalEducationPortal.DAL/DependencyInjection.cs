using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TechnicalEducationPortal.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDALService(this IServiceCollection services)
        {
            services.AddScoped<IDbOperations, SqlDbOperations>();
            return services;
        }
    }
}
