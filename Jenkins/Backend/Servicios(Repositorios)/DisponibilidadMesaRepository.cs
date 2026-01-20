using Jenkins.Backend.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jenkins.Backend.Repositorios
{
    public class DisponibilidadMesaRepository : IDisponibilidadMesaRepository
    {
        private readonly PracticaDllContext _context;

        public DisponibilidadMesaRepository(PracticaDllContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DisponibilidadMesa>> GetAllAsync()
        {
            return await _context.Set<DisponibilidadMesa>()
                .Include(d => d.IdMesaNavigation)
                .ToListAsync();
        }

        public async Task<DisponibilidadMesa?> GetByIdAsync(int id)
        {
            return await _context.Set<DisponibilidadMesa>()
                .Include(d => d.IdMesaNavigation)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<DisponibilidadMesa>> GetByMesaAsync(int idMesa)
        {
            return await _context.Set<DisponibilidadMesa>()
                .Where(d => d.IdMesa == idMesa)
                .ToListAsync();
        }

        public async Task<DisponibilidadMesa> AddAsync(DisponibilidadMesa disponibilidad)
        {
            _context.Set<DisponibilidadMesa>().Add(disponibilidad);
            await _context.SaveChangesAsync();
            return disponibilidad;
        }

        public async Task<DisponibilidadMesa> UpdateAsync(DisponibilidadMesa disponibilidad)
        {
            _context.Set<DisponibilidadMesa>().Update(disponibilidad);
            await _context.SaveChangesAsync();
            return disponibilidad;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var disponibilidad = await GetByIdAsync(id);
            if (disponibilidad == null)
                return false;

            _context.Set<DisponibilidadMesa>().Remove(disponibilidad);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
