using HocicosBack.Models;
using HocicosBacks.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IProductosRepository
    {
        Task<List<Productos>> GetProductos();
        Task<bool> PostProductos(Productos productos);
        Task<ProductosRepository> GetProductosByID(int id);
        Task<bool> UpdateProductos(Productos productos);
        Task<bool> DeleteProductos(int id);

    }
}