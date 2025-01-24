

using HRMS.Infrastructure;
using TechnicalEducationPortal.DAL;

namespace TechnicalEducationPortal.Configurations
{
    public class AddApplicationServices : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDALService();
            services.AddInfrastructureServices();
            services.AddControllers();
            services.AddHttpContextAccessor();

        }
    }
}
