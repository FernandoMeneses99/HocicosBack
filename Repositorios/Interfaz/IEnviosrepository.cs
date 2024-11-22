using HocicosBack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HocicosBack.Repositories
{
    public interface IEnviosRepository
    {
        Task<IEnumerable<Envios>> GetAllEnviosAsync();
        Task<Envios?> GetEnvioByIdAsync(int id);
        Task AddEnvioAsync(Envios envio);
        Task UpdateEnvioAsync(Envios envio);
        Task DeleteEnvioAsync(int id);
        Task GetEnvios();
        Task GetEnviosByID(int id);
        Task<bool> PostEnvios(Envios envios);
        Task<bool> UpdateEnvios(Envios envios);
        Task<bool> DeleteEnvios(int id);
    }
}
