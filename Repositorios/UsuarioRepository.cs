using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;
using HocicosBack.Models;

namespace HocicosBack.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //defifniendo una variable global
        private readonly HocicosContext _context;

        public UsuarioRepository(HocicosContext context)
        {
            _context = context;
        }


        public async Task<List<Clientes>> GetUsuario()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetUsuarioByID(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<bool> PostUsuario(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUsuario(Clientes clientes)
        {
            _context.Clientes.Update(clientes);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
                return false;

            _context.Clientes.Remove(clientes);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

