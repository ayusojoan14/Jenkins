using Jenkins.Backend.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins.Backend.Servicios_Repositorios_
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly PracticaDllContext _context;

        public ReservaRepository(PracticaDllContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            return await _context.Reservas
                .Include(r => r.DniClienteNavigation)
                .Include(r => r.IdPersonalNavigation)
                .Include(r => r.IdMesas)
                .ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _context.Reservas
                .Include(r => r.DniClienteNavigation)
                .Include(r => r.IdPersonalNavigation)
                .Include(r => r.IdMesas)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reserva reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reserva = await GetByIdAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Reservas.AnyAsync(r => r.Id == id);
        }
    }
}
