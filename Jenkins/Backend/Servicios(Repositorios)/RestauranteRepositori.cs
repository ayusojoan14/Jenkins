using Jenkins.Backend.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins.Backend.Servicios_Repositorios_
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly PracticaDllContext _context;

        public RestauranteRepository(PracticaDllContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Restaurante>> GetAllAsync()
        {
            return await _context.Restaurantes
                .Include(r => r.Mesas)
                .Include(r => r.Personals)
                .ToListAsync();
        }

        public async Task<Restaurante?> GetByIdAsync(int id)
        {
            return await _context.Restaurantes
                .Include(r => r.Mesas)
                .Include(r => r.Personals)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Restaurante restaurante)
        {
            _context.Restaurantes.Update(restaurante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var restaurante = await GetByIdAsync(id);
            if (restaurante != null)
            {
                _context.Restaurantes.Remove(restaurante);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Restaurantes.AnyAsync(r => r.Id == id);
        }
    }
}
