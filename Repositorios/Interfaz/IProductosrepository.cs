using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IProductosRepository
    {
        Task<List<Productos>> GetProductos();
        Task<bool> PostProductos(Productos productos);
        Task<Productos> GetProductosByID(int id);
        Task<bool> UpdateProductos(Productos productos);
        Task<bool> DeleteProductos(int id);

    }
}