using Jenkins.Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins.Backend.Servicios_Repositorios_
{
    public interface IRestauranteRepository
    {
        Task<IEnumerable<Restaurante>> GetAllAsync();
        Task<Restaurante?> GetByIdAsync(int id);
        Task AddAsync(Restaurante restaurante);
        Task UpdateAsync(Restaurante restaurante);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
