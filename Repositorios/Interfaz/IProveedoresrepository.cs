using HocicosBack.Models;

namespace HocicosBack.Repositorios.Interfaz
{
    public interface IProveedoresRepository
    {
        Task<List<Proveedores>> GetProveedores();
        Task<bool> PostProveedores(Proveedores proveedores);
        Task<Proveedores> GetProveedoresByID(int id);
        Task<bool> UpdateProveedores(Proveedores proveedores);
        Task<bool> DeleteProveedores(int id);

    }
}