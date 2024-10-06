using HocicosBack.Repositorios.Interfaz;
using HocicosBack.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using HocicosBack.Models;

namespace HocicosBack.Repositorios
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly HocicosContext _context;

        public ClientesRepository(HocicosContext context)
        {
            _context = context;
        }
    }

    public async Task<List<Clientes>> GetClientes()
    {
        return await context.Clientes.ToListAsync();
    }
}
