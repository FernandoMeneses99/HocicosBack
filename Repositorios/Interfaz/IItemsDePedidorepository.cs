using HocicosBack.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IItemsDePedidoRepository
    {
        Task<List<ItemsDePedido>> GetItemsDePedidos();
        Task<bool> PostItemsDePedido (ItemsDePedido itemsDePedido);
        Task<ItemsDePedido> GetItemsDePedidoByID(int id);
        Task<bool> UpdateItemsDePedido(ItemsDePedido itemsDePedido);
        Task<bool> DeleteItemsDePedido (int id);

    }
}


