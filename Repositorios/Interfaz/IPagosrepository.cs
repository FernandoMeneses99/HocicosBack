using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IPagosRepository
    {
        Task<List<Pagos>> GetPagos();
        Task<bool> PostPagos(Pagos pagos);
        Task<Pagos> GetPagosByID(int id);
        Task<bool> UpdatePagos(Pagos pagos);
        Task<bool> DeletePagos(int id);

    }
}