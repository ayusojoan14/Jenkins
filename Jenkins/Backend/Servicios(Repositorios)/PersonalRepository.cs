using Jenkins.Backend.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins.Backend.Servicios_Repositorios_
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly PracticaDllContext _context;

        public PersonalRepository(PracticaDllContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personal>> GetAllAsync()
        {
            return await _context.Personals
                .Include(p => p.Horario)
                .Include(p => p.Rol)
                .Include(p => p.IdRestauranteNavigation)
                .Include(p => p.Reservas)
                .Include(p => p.Usuarios)
                .Include(p => p.IdPlatos)
                .ToListAsync();
        }

        public async Task<Personal?> GetByIdAsync(int id)
        {
            return await _context.Personals
                .Include(p => p.Horario)
                .Include(p => p.Rol)
                .Include(p => p.IdRestauranteNavigation)
                .Include(p => p.Reservas)
                .Include(p => p.Usuarios)
                .Include(p => p.IdPlatos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Personal personal)
        {
            _context.Personals.Add(personal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Personal personal)
        {
            _context.Personals.Update(personal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var personal = await GetByIdAsync(id);
            if (personal != null)
            {
                _context.Personals.Remove(personal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Personals.AnyAsync(p => p.Id == id);
        }
    }
}
