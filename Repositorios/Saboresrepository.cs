using HocicosBack.Models;
using HocicosBack.Repositorios.Interfaz;
using Microsoft.EntityFrameworkCore;

namespace HocicosBack.Repositorios
{
    public class Saboresrepository : ISaboresRepository
    {
        
        private readonly HocicosContext _context;

        public Saboresrepository(HocicosContext context)
        {
            _context = context;
        }


        public async Task<List<Sabores>> GetSabores()
        {
            return await _context.Sabores.ToListAsync();
        }

        public async Task<Sabores> GetSaboresByID(int id)
        {
            return await _context.Sabores.FindAsync(id);
        }

        public async Task<bool> PostSabores(Sabores sabores)
        {
            _context.Sabores.Add(sabores);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSabores(Sabores sabores)
        {
            _context.Sabores.Update(sabores);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteSabores(int id)
        {
            var Sabores = await _context.Sabores.FindAsync(id);
            if (Sabores == null)
                return false;

            _context.Sabores.Remove(Sabores);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}