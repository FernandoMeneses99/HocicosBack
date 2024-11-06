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
            services.AddScoped<IEnviosRepository, Enviosrepository>();
            services.AddScoped<IItemsDePedidoRepository, ItemsDePedidoRepository>();
            services.AddScoped<IPagosRepository, PagosRepository>();
            services.AddScoped<IPedidosRepository, PedidosRepository>();
            services.AddScoped<IProductoRepository, ProductosRepository>();
            services.AddScoped<IProveedoresRepository, ProveedoresRepository>();
            services.AddScoped<ISaboresRepository, Saboresrepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}