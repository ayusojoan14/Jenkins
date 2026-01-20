using Jenkins.Backend.Modelo;
using Jenkins.Backend.Servicios_Repositorios_;
using System.Threading;
using System.Threading.Tasks;

namespace Jenkins.Backend.Servicios
{
    /// <summary>
    /// Interfaz específica para el repositorio de <see cref="Cliente"/>.
    /// </summary>
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        /// <summary>
        /// Obtiene un cliente por su DNI (sin tracking).
        /// </summary>
        Task<Cliente?> GetByDniAsync(string dni, CancellationToken cancellationToken = default);

        /// <summary>
        /// Comprueba si existe un cliente con el DNI indicado.
        /// </summary>
        Task<bool> ExistsByDniAsync(string dni, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene un cliente con sus relaciones (Pedidos, Reservas y Usuarios).
        /// </summary>
        Task<Cliente?> GetWithRelationsAsync(string dni, CancellationToken cancellationToken = default);
    }
}
