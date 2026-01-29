using Jenkins.Backend.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jenkins.Backend.Repositorios
{
    public class HorarioRepository : IHorarioRepository
    {
        private readonly PracticaDllContext _context;

        public HorarioRepository(PracticaDllContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Horario>> GetAllAsync()
        {
            return await _context.Set<Horario>().ToListAsync();
        }

        public async Task<Horario?> GetByIdAsync(int id)
        {
            return await _context.Set<Horario>()
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Horario> AddAsync(Horario horario)
        {
            _context.Set<Horario>().Add(horario);
            await _context.SaveChangesAsync();
            return horario;
        }

        public async Task<Horario> UpdateAsync(Horario horario)
        {
            _context.Set<Horario>().Update(horario);
            await _context.SaveChangesAsync();
            return horario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var horario = await GetByIdAsync(id);
            if (horario == null)
                return false;

            _context.Set<Horario>().Remove(horario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
