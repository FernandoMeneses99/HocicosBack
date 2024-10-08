using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;
using HocicosBack.Models;

namespace HocicosBack.Repositorios
{
    public class ItemsDePedidoRepository : IItemsDePedidoRepository
    {
        private readonly HocicosContext _context;

        public ItemsDePedidoRepository(HocicosContext context)
        {
            _context = context;
        }

        public async Task<List<ItemsDePedido>> GetItemsDePedido()
        {
            return await _context.ItemsDePedido.ToListAsync();
        }

        public async Task<ItemsDePedido> GetItemDePedidoByID(int id)
        {
            return await _context.ItemsDePedido.FindAsync(id);
        }

        public async Task<bool> PostItemsDePedido(ItemsDePedido itemsDePedido)
        {
            _context.ItemsDePedido.Add(itemsDePedido);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateItemsDePedido(ItemsDePedido itemsDePedido)
        {
            _context.ItemsDePedido.Update(itemsDePedido);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemsDePedido(int id)
        {
            var ItemDePedido = await _context.ItemsDePedido.FindAsync(id);
            if (ItemDePedido == null)
                return false;

            _context.ItemsDePedido.Remove(ItemDePedido);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
