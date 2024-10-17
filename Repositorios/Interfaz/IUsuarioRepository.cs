using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IUsuarioRepository
    {
        Task<List<Clientes>> GetUsuario();
        Task<Clientes> GetUsuarioByEmail(string email);
        Task<bool> PostUsuario(Clientes clientes);
        Task<Clientes> GetUsuarioByID(int id);
        Task<bool> UpdateUsuario(Clientes clientes);
        Task<bool> DeleteUsuario(int id);

    }
}
