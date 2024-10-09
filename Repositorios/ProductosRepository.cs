using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;
using HocicosBack.Models;

namespace HocicosBack.Repositorios
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly HocicosContext _context;

        public ProductosRepository(HocicosContext context)
        {
            _context = context;
        }

        public async Task<List<Productos>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Productos> GetProductoByID(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<bool> PostProductos(Productos productos)
        {
            _context.Productos.Add(productos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProductos(Productos productos)
        {
            _context.Productos.Update(productos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return false;

            _context.Productos.Remove(productos);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<ProductosRepository> GetProductosByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductos(int id)
        {
            throw new NotImplementedException();
        }
    }
}
