using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;
using HocicosBack.Models;

namespace HocicosBack.Repositorios
{
    public class PagosRepository : IPagosRepository
    {
        private readonly HocicosContext _context;

        public PagosRepository(HocicosContext context)
        {
            _context = context;
        }

        public async Task<List<Pagos>> GetPagos()
        {
            return await _context.Pagos.ToListAsync();
        }

        public async Task<Pagos> GetPagosByID(int id)
        {
            return await _context.Pagos.FindAsync(id);
        }

        public async Task<bool> PostPagos(Pagos pago)
        {
            _context.Pagos.Add(pago);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePagos(Pagos pago)
        {
            _context.Pagos.Update(pago);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePagos(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
                return false;

            _context.Pagos.Remove(pago);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
