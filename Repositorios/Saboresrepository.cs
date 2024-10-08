using HocicosBack.Models;
using HocicosBack.Repositorios.Interfaz;
using HocicosBacks.Models;
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

        public async Task<bool> PostSabores(Sabores Sabores)
        {
            _context.Sabores.Add(Sabores);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateSabores(Sabores Sabores)
        {
            _context.Sabores.Update(Sabores);
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