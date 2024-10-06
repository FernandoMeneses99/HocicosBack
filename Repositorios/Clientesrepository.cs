using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;
using HocicosBack.Models;

namespace HocicosBack.Repositorios
{
    public class ClientesRepository : IClientesRepository
    {
        //defifniendo una variable global
        private readonly HocicosContext _context;

        public ClientesRepository(HocicosContext context)
        {
            _context = context;
        }


        public async Task<List<Clientes>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetClientesByID(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<bool> PostClientes(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateClientes(Clientes clientes)
        {
            _context.Clientes.Update(clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteClientes(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
                return false;

            _context.Clientes.Remove(clientes);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
