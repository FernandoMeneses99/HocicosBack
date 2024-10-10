using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;
using HocicosBack.Models;

namespace HocicosBack.Repositorios
{
    public class PedidosRepository : IPedidosRepository
    {
        private readonly HocicosContext _context;

        public PedidosRepository(HocicosContext context)
        {
            _context = context;
        }

        public async Task<List<Pedidos>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedidos> GetPedidosByID(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task<bool> PostPedidos(Pedidos pedidos)
        {
            _context.Pedidos.Add(pedidos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePedidos(Pedidos pedidos)
        {
            _context.Pedidos.Update(pedidos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePedidos(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
                return false;

            _context.Pedidos.Remove(pedido);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
