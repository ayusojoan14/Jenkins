using Jenkins.Backend.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jenkins.Backend.Repositorios
{
    public interface IMesaRepository
    {
        Task<IEnumerable<Mesa>> GetAllAsync();
        Task<Mesa?> GetByIdAsync(int id);
        Task<Mesa> AddAsync(Mesa mesa);
        Task<Mesa> UpdateAsync(Mesa mesa);
        Task<bool> DeleteAsync(int id);
    }
}
