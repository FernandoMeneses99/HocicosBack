using HocicosBack.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IItemsDePedidoRepository
    {
        Task<List<ItemsDePedido>> GetItemsDePedido();
        Task<bool> PostItemsDePedido(ItemsDePedido itemsDePedido);
        Task<ItemsDePedido> GetItemDePedidoByID(int id); 
        Task<bool> UpdateItemsDePedido(ItemsDePedido itemsDePedido);
        Task<bool> DeleteItemsDePedido(int id);
    }
}


