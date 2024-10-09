using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;
using HocicosBack.Models;

namespace HocicosBack.Repositorios
{
    public class ProveedoresRepository : IProveedoresRepository
    {
        private readonly HocicosContext _context;

        public ProveedoresRepository(HocicosContext context)
        {
            _context = context;
        }

        public async Task<List<Proveedores>> GetProveedores()
        {
            return await _context.Proveedores.ToListAsync();
        }

        public async Task<Proveedores> GetProveedoresByID(int id)
        {
            return await _context.Proveedores.FindAsync(id);
        }

        public async Task<bool> PostProveedores(Proveedores proveedores)
        {
            _context.Proveedores.Add(proveedores);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProveedores(Proveedores proveedores)
        {
            _context.Proveedores.Update(proveedores);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProveedores(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
                return false;

            _context.Proveedores.Remove(proveedor);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
