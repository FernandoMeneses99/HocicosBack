using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IPedidosRepository
    {
        Task<List<Pedidos>> GetPedidos();
        Task<bool> PostPedidos(Pedidos pedidos);
        Task<Pedidos> GetPedidosByID(int id);
        Task<bool> UpdatePedidos(Pedidos pedidos);
        Task<bool> DeletePedidos(int id);

    }
}
