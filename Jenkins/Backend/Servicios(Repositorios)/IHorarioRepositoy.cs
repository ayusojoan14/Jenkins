using Jenkins.Backend.Modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jenkins.Backend.Repositorios
{
    public interface IHorarioRepository
    {
        Task<IEnumerable<Horario>> GetAllAsync();
        Task<Horario?> GetByIdAsync(int id);
        Task<Horario> AddAsync(Horario horario);
        Task<Horario> UpdateAsync(Horario horario);
        Task<bool> DeleteAsync(int id);
    }
}
