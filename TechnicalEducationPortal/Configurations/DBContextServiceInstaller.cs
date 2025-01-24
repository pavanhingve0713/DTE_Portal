using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using TechnicalEducationPortal.Data;

namespace TechnicalEducationPortal.Configurations
{
    public class DBContextServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(_ => new SqlConnection(configuration.GetConnectionString("DBConnection")));

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DBConnection"));
            });

        }
    }
}
