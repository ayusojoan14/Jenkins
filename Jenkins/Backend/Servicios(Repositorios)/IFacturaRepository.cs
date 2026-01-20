using Jenkins.Backend.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jenkins.Backend.Repositorios
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> GetAllAsync();
        Task<Factura?> GetByIdAsync(int id);
        Task<Factura?> GetByPedidoIdAsync(int idPedido);
        Task<Factura> AddAsync(Factura factura);
        Task<Factura> UpdateAsync(Factura factura);
        Task<bool> DeleteAsync(int id);
    }
}
