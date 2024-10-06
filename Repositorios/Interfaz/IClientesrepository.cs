using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IClientesRepository
    {
        Task<List<Clientes>> GetClientes();
        Task<bool> PostClientes(Clientes clientes);
        Task<Clientes> GetClientesByID(int id);
        Task<bool> UpdateClientes(Clientes clientes);
        Task<bool> DeleteClientes(int id);

    }
}
