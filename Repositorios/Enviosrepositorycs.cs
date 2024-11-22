using HocicosBack.Data;
using HocicosBack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HocicosBack.Repositories
{
    public class EnviosRepository : IEnviosRepository
    {
        private readonly ApplicationDbContext _context;

        public EnviosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Envios>> GetAllEnviosAsync()
        {
            return await _context.Envios.ToListAsync();
        }

        public async Task<Envios?> GetEnvioByIdAsync(int id)
        {
            return await _context.Envios.FindAsync(id);
        }

        public async Task AddEnvioAsync(Envios envio)
        {
            await _context.Envios.AddAsync(envio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEnvioAsync(Envios envio)
        {
            _context.Envios.Update(envio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEnvioAsync(int id)
        {
            var envio = await GetEnvioByIdAsync(id);
            if (envio != null)
            {
                _context.Envios.Remove(envio);
                await _context.SaveChangesAsync();
            }
        }
    }
}
