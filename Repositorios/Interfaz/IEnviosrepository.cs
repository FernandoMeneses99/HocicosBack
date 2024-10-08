using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IEnviosRepository
    {
        Task<List<Envios>> GetEnvios();
        Task<bool> PostEnvios(Envios envios);
        Task<Envios> GetEnviosByID(int id);
        Task<bool> UpdateEnvios(Envios envios);
        Task<bool> DeleteEnvios(int id);

    }
}
