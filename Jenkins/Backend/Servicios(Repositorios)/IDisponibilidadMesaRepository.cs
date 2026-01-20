using Jenkins.Backend.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jenkins.Backend.Repositorios
{
    public interface IDisponibilidadMesaRepository
    {
        Task<IEnumerable<DisponibilidadMesa>> GetAllAsync();
        Task<DisponibilidadMesa?> GetByIdAsync(int id);
        Task<IEnumerable<DisponibilidadMesa>> GetByMesaAsync(int idMesa);
        Task<DisponibilidadMesa> AddAsync(DisponibilidadMesa disponibilidad);
        Task<DisponibilidadMesa> UpdateAsync(DisponibilidadMesa disponibilidad);
        Task<bool> DeleteAsync(int id);
    }
}
