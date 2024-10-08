using HocicosBack.Models;
using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace HocicosBack.Repositorios
{
    public class Enviosrepository : IEnviosRepository
    {
           private readonly HocicosContext _context;

            public Enviosrepository(HocicosContext context)
            {
                _context = context;
            }

            // Obtener todos los envíos
            public async Task<List<Envios>> GetEnvios()
            {
                return await _context.Envios.ToListAsync();
            }

            // Obtener un envío por su ID
            public async Task<Envios> GetEnviosByID(int id)
            {
                return await _context.Envios.FindAsync(id);
            }

            // Insertar un nuevo envío
            public async Task<bool> PostEnvios(Envios envios)
            {
                _context.Envios.Add(envios);
                return await _context.SaveChangesAsync() > 0;
            }

            // Actualizar un envío existente
            public async Task<bool> UpdateEnvios(Envios envios)
            {
                _context.Envios.Update(envios);
                return await _context.SaveChangesAsync() > 0;
            }

            // Eliminar un envío por su ID
            public async Task<bool> DeleteEnvios(int id)
            {
                var envios = await _context.Envios.FindAsync(id);
                if (envios == null)
                    return false;

                _context.Envios.Remove(envios);
                return await _context.SaveChangesAsync() > 0;
            }

    }
}
