using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface ISaboresRepository
    {
        Task<List<Sabores>> GetSabores();
        Task<bool> PostSabores(Sabores sabores);
        Task<ISaboresRepository> GetSaboresByID(int id);
        Task<bool> UpdateSabores(Sabores sabores);
        Task<bool> DeleteSabores(int id);

    }
}