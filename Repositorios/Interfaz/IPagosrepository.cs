using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IPagosRepository
    {
        Task<List<Pagos>> GetPagos();
        Task<bool> PostPagos (Pagos pago);
        Task<Pagos> GetPagosByID(int id);
        Task<bool> UpdatePagos(Pagos pago);
        Task<bool> DeletePagos (int id);

    }
}
