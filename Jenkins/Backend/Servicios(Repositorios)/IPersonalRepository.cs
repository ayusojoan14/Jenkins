using Jenkins.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins.Backend.Servicios_Repositorios_
{
    public interface IPersonalRepository
    {
        Task<IEnumerable<Personal>> GetAllAsync();
        Task<Personal?> GetByIdAsync(int id);
        Task AddAsync(Personal personal);
        Task UpdateAsync(Personal personal);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
