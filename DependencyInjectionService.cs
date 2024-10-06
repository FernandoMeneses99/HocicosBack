using HocicosBack.Repositorios;
using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace HocicosBack
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = "";
            connectionString = _configuration["ConnectionStrings:SQLConnectionStrings"];

            services.AddDbContext<HocicosContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IClientesRepository, ClientesRepository>();
           //hacer el de las demas tablas



            return services;
        }
    }
}