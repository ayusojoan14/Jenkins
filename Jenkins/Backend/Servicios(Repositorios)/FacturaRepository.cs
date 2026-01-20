using Jenkins.Backend.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jenkins.Backend.Repositorios
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly PracticaDllContext _context;

        public FacturaRepository(PracticaDllContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _context.Set<Factura>()
                .Include(f => f.IdPedidoNavigation)
                .ToListAsync();
        }

        public async Task<Factura?> GetByIdAsync(int id)
        {
            return await _context.Set<Factura>()
                .Include(f => f.IdPedidoNavigation)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Factura?> GetByPedidoIdAsync(int idPedido)
        {
            return await _context.Set<Factura>()
                .Include(f => f.IdPedidoNavigation)
                .FirstOrDefaultAsync(f => f.IdPedido == idPedido);
        }

        public async Task<Factura> AddAsync(Factura factura)
        {
            _context.Set<Factura>().Add(factura);
            await _context.SaveChangesAsync();
            return factura;
        }

        public async Task<Factura> UpdateAsync(Factura factura)
        {
            _context.Set<Factura>().Update(factura);
            await _context.SaveChangesAsync();
            return factura;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var factura = await GetByIdAsync(id);
            if (factura == null)
                return false;

            _context.Set<Factura>().Remove(factura);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
