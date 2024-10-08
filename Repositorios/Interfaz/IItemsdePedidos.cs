using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IItemsDePedidosRepository
    {
        Task<List<ItemsDePedido>> GetItemsDePedidos();
        Task<bool> PostItemsDePedidos(ItemsDePedido itemsDePedido);
        Task<ItemsDePedido> GetItemsDePedidosByID(int id);
        Task<bool> UpdateItemsDePedidos(ItemsDePedido itemsDePedido);
        Task<bool> DeleteItemsDePedidos(int id);

    }
}