using HocicosBack.Models;
using HocicosBacks.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IProductoRepository
    {
        Task<List<Productos>> GetProductos();
        Task<bool> PostProductos(Productos productos);
        Task<Productos> GetProductosByID(int id);
        Task<bool> UpdateProductos(Productos productos);
        Task<bool> DeleteProductos(int id);

    }
}