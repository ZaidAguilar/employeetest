using EjemploApplication.Properties;
using EjemploApplication.Service;

namespace EjemploApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=employees.db"));
            services.AddScoped<EmployeeService>();
            services.AddControllers();
        }

    }
}
