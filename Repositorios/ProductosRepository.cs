using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;
using HocicosBack.Models;
using HocicosBacks.Models;

namespace HocicosBack.Repositorios
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly HocicosContext _context;

        public ProductosRepository(HocicosContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetProductoByID(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<bool> PostProductos(Producto producto)
        {
            _context.Productos.Add(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProductos(Producto producto)
        {
            _context.Productos.Update(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return false;

            _context.Productos.Remove(producto);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
