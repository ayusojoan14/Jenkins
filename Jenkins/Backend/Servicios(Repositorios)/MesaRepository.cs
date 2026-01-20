using Jenkins.Backend.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jenkins.Backend.Repositorios
{
    public class MesaRepository : IMesaRepository
    {
        private readonly PracticaDllContext _context;

        public MesaRepository(PracticaDllContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mesa>> GetAllAsync()
        {
            return await _context.Set<Mesa>()
                .Include(m => m.DisponibilidadMesas)
                .Include(m => m.IdReservas)
                .ToListAsync();
        }

        public async Task<Mesa?> GetByIdAsync(int id)
        {
            return await _context.Set<Mesa>()
                .Include(m => m.DisponibilidadMesas)
                .Include(m => m.IdReservas)
                .FirstOrDefaultAsync(m => m.IdMesa == id);
        }

        public async Task<Mesa> AddAsync(Mesa mesa)
        {
            _context.Set<Mesa>().Add(mesa);
            await _context.SaveChangesAsync();
            return mesa;
        }

        public async Task<Mesa> UpdateAsync(Mesa mesa)
        {
            _context.Set<Mesa>().Update(mesa);
            await _context.SaveChangesAsync();
            return mesa;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var mesa = await GetByIdAsync(id);
            if (mesa == null)
                return false;

            _context.Set<Mesa>().Remove(mesa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
